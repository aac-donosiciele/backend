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

namespace DonosServer.API.Controllers
{
    [ApiController]
    [Route("/official")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class OfficialController : ControllerBase
    {
        private readonly IOfficialService officialService;
        private readonly IUserService userService;

        private readonly IComplaintService complaintService;
        private readonly IComplaintLogService complaintLogService;
        private readonly UserContext userContext;


        public OfficialController(IOfficialService officialService,
                                  IUserService userService,
                                  IComplaintService complaintService,
                                  IComplaintLogService complaintLogService,
                                  UserContext userContext)
        {
            this.officialService = officialService;
            this.userService = userService;
            this.complaintService = complaintService;
            this.complaintLogService = complaintLogService;
            this.userContext = userContext;
        }
        
        
        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("{id}/complaints")]
        public ActionResult<IEnumerable<GetOfficialComplaintResponse>> GetOfficialComplaints(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return NotFound("Official with given ID not found");
            }
            var official = officialService.Get(guid);
            if (official is null)
                return NotFound("Official with given ID not found");
            
            var compl = complaintService.GetOfficialComplaints(official.Id);
            var res = compl.Select(x => new GetOfficialComplaintResponse()
            {
                Category = Mapper.CategoryString(x.Category).Title,
                Id = x.Id.ToString(),
                Note = x.Note,
                SendDate = x.SendTime,
                TargetAddress = x.TargetAddress,
                TargetFirstName = x.TargetFirstName,
                TargetLastName = x.TargetLastName,
                Status = Mapper.OfficialComplaintStatus(complaintLogService.GetComplaintLogs(x.Id)
                .OrderByDescending(y => y.UpdateTime).First().Status)
            });
            return Ok(res);
            
        }

        [AdminAuthorization]
        [HttpGet("/users")]
        public ActionResult<IEnumerable<GetUsers>> GetUsers()
        {
            var users = this.userService.GetAll();
            var res = users.Select(x => new GetUsers()
            {
                Id = x.Id,
                Role = (int)x.Role,
                Username = x.Username,
            });
            return Ok(res);
        }

        [AdminAuthorization]
        [HttpPost("/makeOfficial")]
        public IActionResult UpdateToOfficial(MakeOfficial makeOfficial)
        {
            if (!Guid.TryParse(makeOfficial.Id, out Guid guid))
            {
                return NotFound("User with given ID not found");
            }
            var user = userService.Get(guid);
            user.Role = Role.Official;
            this.userService.Edit(user);
            Random r = new Random();
            officialService.Add(new Official()
            {
                Category = (ComplaintCategory)r.Next(0, 7),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Id = user.Id
            });
            return NoContent();
        }

        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpPost("/officialComplaint")]
        public IActionResult UpdateComplaint(UpdateComplaintRequest request)
        {
            if (this.userContext.Id.ToString() != request.OfficialId)
                return NotFound();
            this.complaintLogService.Add(new ComplaintLog
            {
                ComplaintId = new Guid(request.ComplaintId),
                Status = request.Status,
                OfficialId = Guid.Parse(request.OfficialId)
            });
            return NoContent();
        }

        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("complaint/{id}")]
        public ActionResult<GetComplaintResponse> GetComplaint(string id)
        {
            var result = complaintService.Get(new Guid(id));
            return result switch
            {
                null => NotFound(),
                not null => Ok(new GetComplaintResponse
                {
                    History = complaintLogService.GetComplaintLogs(result.Id).Select(x => new GetComplaintLogResponse
                    {
                        Status = Mapper.OfficialComplaintStatus(x.Status),
                        ComplaintId = x.ComplaintId.ToString(),
                        OfficialId = x.OfficialId.ToString(),
                        UpdateDate = x.UpdateTime
                    })
                })
            };
        }
    }
}
