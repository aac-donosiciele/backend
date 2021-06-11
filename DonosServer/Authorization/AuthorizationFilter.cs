using Core.Entities;
using DonosServer.API.Authorization.Attributes;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonosServer.API.Authorization
{
    public class AuthorizationFilter : IActionFilter
    {
        private readonly DonosContext dbContext;
        private readonly UserContext userContext;

        public AuthorizationFilter(DonosContext dbContext, UserContext userContext)
        {
            this.dbContext = dbContext;
            this.userContext = userContext;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var roles = GetAuthorizedRoles(context.ActionDescriptor as ControllerActionDescriptor).ToList();
            if (roles.Count == 0)
                return;

            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Result = new UnauthorizedObjectResult("Unauthorized");
                return;
            }

            string username;
            try
            {
                username = Encoding.UTF8.GetString(Convert.FromBase64String(token.ToString().Replace("Bearer ", "")));
            }
            catch (FormatException)
            {
                context.Result = new UnauthorizedObjectResult("Unauthorized");
                return;
            }

            var user = dbContext.Users.SingleOrDefault(x => x.Username == username) ?? (UserBase)dbContext.Officials.SingleOrDefault(x => x.Username == username);
            if (user is null)
            {
                context.Result = new UnauthorizedObjectResult("Unauthorized");
                return;
            }
            if (!roles.Contains(user.Role))
            {
                context.Result = new ObjectResult("Insufficient permissions")
                {
                    StatusCode = StatusCodes.Status403Forbidden,
                };
            }
            
            userContext.SetOnce(user.Id);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }

        private static IEnumerable<Role> GetAuthorizedRoles(ControllerActionDescriptor descriptor)
        {
            return descriptor.MethodInfo.GetCustomAttributes(typeof(AuthorizationAttribute), true).Select(x => ((AuthorizationAttribute)x).Role);
        }
    }
}
