using Core;
using Core.Entities;
using Core.Interfaces;
using DonosServer.API.Authorization;
using DonosServer.API.Authorization.Attributes;
using DonosServer.API.DTOs.Requests;
using DonosServer.API.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonosServer.API.Controllers
{
    [ApiController]
    [Route("/user")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IComplaintService complaintService;
        private readonly IComplaintLogService complaintLogService;
        private readonly IAuthorityService authorityService;

        private readonly UserContext userContext;

        public UserController(IUserService userService, IComplaintService complaintService, IComplaintLogService complaintLogService, IAuthorityService authorityService, UserContext userContext)
        {
            this.userService = userService;
            this.complaintService = complaintService;
            this.complaintLogService = complaintLogService;
            this.authorityService = authorityService;
            this.userContext = userContext;
        }
        
        [HttpPut]
        public IActionResult EditUser(EditUserRequest request)
        {
            var user = userService.Get(new Guid(request.Id));
            user.Pesel = request.Pesel;
            user.IsVerified = request.Verified;
            userService.Edit(user);
            return Ok();
        }

        [HttpPost("complaints")]
        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        public IActionResult CreateComplaint(CreateComplaintRequest request)
        {
            complaintService.Add(new Complaint
            {
                Category = request.Category,
                Note = request.Note,
                CreatedDate = DateTime.Now,
                SenderId = new Guid(request.SenderId),
                SendTime = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                TargetFirstName = request.TargetFirstName,
                TargetLastName = request.TargetLastName
            });
            return Ok();
        }

        [HttpGet("{id}/complaints")]
        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        public ActionResult<IEnumerable<GetUserComplaintResponse>> GetUserComplaints(string id)
        {
            var user = userService.Get(new Guid(id));
            return user switch
            {
                null => NotFound("User with given ID not found"),
                not null => Ok(user.Complaints.Select(x => new GetUserComplaintResponse
                {
                    Category = x.Category,
                    Id = x.Id.ToString(),
                    Note = x.Note,
                    SendDate = x.SendTime,
                    Status = Mapper.UserComplaintStatus(x.ComplaintLogs.OrderByDescending(y => y.UpdateTime).First().Status),
                    TargetFirstName = x.TargetFirstName,
                    TargetLastName = x.TargetLastName
                }))
            };
        }

        [HttpDelete("complaints/{id}")]
        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        public IActionResult CancelComplaint(string id)
        {
            var complaint = complaintService.Get(new Guid(id));
            if (complaint is null)
                return NotFound("Complaint with given ID not found");
            complaintLogService.CancelComplaint(new Guid(id));
            return Ok();
        }

        [HttpPost("/login")]
        public ActionResult<LogInResponse> LogIn(LogInRequest request)
        {
            var user = this.userService.GetByUsernameAndPassword(request.Login, request.Password);
            if (user is null)
                return Unauthorized("Bad credentials");
            return Ok(new LogInResponse
            {
                Role = user.Role,
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username))
            });
        }

        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("/categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var tmp = this.authorityService.GetAll(ComplaintCategory.GlownyInspektoratSanitarny, true);
            var categories = new List<Category>();
            foreach (var item in tmp.ToList())
                categories.Add(Mapper.CategoryString(item.Category));
            return Ok(categories);
        }

        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("")]
        public ActionResult<GetUserResponse> GetUser()
        {
            var user = userService.Get(this.userContext.Id);
            return Ok(new GetUserResponse
            {
                Id = user.Id.ToString(),
                IsVerified = user.IsVerified
            });
        }
    }
}
