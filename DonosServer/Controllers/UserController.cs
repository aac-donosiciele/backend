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
        private readonly IOfficialService officialService;

        private readonly UserContext userContext;

        public UserController(IUserService userService, IComplaintService complaintService, IComplaintLogService complaintLogService, IOfficialService officialService, UserContext userContext)
        {
            this.userService = userService;
            this.complaintService = complaintService;
            this.complaintLogService = complaintLogService;
            this.officialService = officialService;
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
            var tmp = new Complaint
            {
                Category = request.Category,
                Note = request.Note,
                CreatedDate = DateTime.Now,
                SenderId = new Guid(request.SenderId),
                SendTime = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                TargetFirstName = request.TargetFirstName,
                TargetLastName = request.TargetLastName
            };
            complaintService.Add(tmp);
            var offs = officialService.GetAll().Where(x => x.Category == request.Category).ToList();
            Random r = new Random();

            complaintLogService.Add(new ComplaintLog()
            {
                Category = request.Category,
                ComplaintId = tmp.Id,
                LastModifiedDate = tmp.LastModifiedDate,
                CreatedDate = tmp.CreatedDate,
                Id = Guid.NewGuid(),
                OfficialId = offs[r.Next(0, offs.Count)].Id,
                Status = DetailedComplaintStatus.Assigned
            }) ;
            return NoContent();
        }

        [HttpGet("{id}/complaints")]
        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        public ActionResult<IEnumerable<GetUserComplaintResponse>> GetUserComplaints(string id)
        {
            if(!Guid.TryParse(id, out Guid guid))
            {
                return NotFound("User with given ID not found");
            }
            var user = userService.Get(guid);

            return user switch
            {
                null => NotFound("User with given ID not found"),
                not null => Ok(complaintService.GetUserComplaints(user.Id).Select(x => new GetUserComplaintResponse
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

        [HttpPost("/register")]
        public ActionResult<RegisterResponse> Register(RegisterRequest request)
        {
            var user = this.userService.GetByUsername(request.Login);
            if (user is not null)
                return Conflict();
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for (int i = 0; i < 11; i++)
            {
                sb.Append(r.Next(10).ToString());
            }
            user = this.userService.Add(new User
            {
                Username = request.Login,
                PasswordHash = Toolbox.ComputeHash(request.Password),
                Pesel = sb.ToString(),
                IsVerified = true
            });
            return new RegisterResponse
            {
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username))
            };
        }

        [UserAuthorization]
        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("/categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var tmp = this.officialService.GetAll();
            var categories = new HashSet<Category>();
            foreach (var item in tmp.ToList())
                categories.Add(Mapper.CategoryString(item.Category));
            return Ok(categories.ToArray());
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
