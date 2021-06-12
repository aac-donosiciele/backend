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
        private readonly IComplaintService complaintService;
        private readonly IComplaintLogService complaintLogService;
        private readonly UserContext userContext;


        public OfficialController(IOfficialService officialService,
                                  IComplaintService complaintService,
                                  IComplaintLogService complaintLogService,
                                  UserContext userContext)
        {
            this.officialService = officialService;
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
            return Ok();
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
