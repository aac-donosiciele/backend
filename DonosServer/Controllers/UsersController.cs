using Core.Entities;
using Core.Interfaces;
using DonosServer.API.DTOs.Requests;
using DonosServer.API.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonosServer.API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IComplaintService complaintService;
        private readonly IComplaintLogService complaintLogService;

        public UsersController(IUserService userService, IComplaintService complaintService, IComplaintLogService complaintLogService)
        {
            this.userService = userService;
            this.complaintService = complaintService;
            this.complaintLogService = complaintLogService;
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

        [HttpGet("{id}")]
        public ActionResult<GetUserResponse> GetUser(string id)
        {
            var user = userService.Get(new Guid(id));
            return user switch
            {
                null => NotFound("User with given ID not found"),
                _ => Ok(new GetUserResponse
                {
                    Id = user.Id.ToString(),
                    Pesel = user.Pesel,
                    Verified = user.IsVerified
                })
            };
        }

        [HttpPost("complaints")]
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
                TargetLastName = request.TargetLastName,
                TargetAddress = request.TargetAddress
            });
            return Ok();
        }

        [HttpGet("{id}/complaints")]
        public ActionResult<IEnumerable<GetUserComplaintResponse>> GetUserComplaints(string id)
        {
            var user = userService.Get(new Guid(id));
            return user switch
            {
                null => NotFound("User with given ID not found"),
                _ => Ok(user.Complaints.Select(x => new GetUserComplaintResponse
                {
                    Category = x.Category,
                    Id = x.Id.ToString(),
                    Note = x.Note,
                    SendDate = x.SendTime,
                    Status = x.ComplaintLogs.OrderByDescending(y => y.UpdateTime).First().Status,
                    TargetAddress = x.TargetAddress,
                    TargetFirstName = x.TargetFirstName,
                    TargetLastName = x.TargetLastName
                }))
            };
        }

        [HttpDelete("complaints/{id}")]
        public IActionResult CancelComplaint(string id)
        {
            var complaint = complaintService.Get(new Guid(id));
            if (complaint is null)
                return NotFound("Complaint with given ID not found");
            complaintLogService.CancelComplaint(new Guid(id));
            return Ok();
        }
    }
}
