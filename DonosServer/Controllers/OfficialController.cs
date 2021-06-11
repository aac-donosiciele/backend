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
    [ServiceFilter(typeof(AuthorizationAttribute))]
    public class OfficialController : ControllerBase
    {
        private readonly IOfficialService officialService;
        private readonly IComplaintService complaintService;
        private readonly IComplaintLogService complaintLogService;
        private readonly IAuthorityService authorityService;
        private readonly UserContext userContext;


        public OfficialController(IOfficialService officialService,
                                  IComplaintService complaintService,
                                  IAuthorityService authorityService,
                                  IComplaintLogService complaintLogService,
                                  UserContext userContext)
        {
            this.officialService = officialService;
            this.complaintService = complaintService;
            this.complaintLogService = complaintLogService;
            this.authorityService = authorityService;
            this.userContext = userContext;
        }
        
        [AdminAuthorization]
        [HttpPost]
        public IActionResult AddOfficial(AddOfficialRequest request)
        {
            officialService.Add(new Official
            {
                Address = request.Address,
                Email = request.Email,
                Id = new Guid(request.Id),
                Pesel = request.Pesel,
                AuthorityId = new Guid(request.AuthorityId),
                CreatedDate = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                LastModifiedDate = DateTime.Now,
                Role = request.Role
            });
            return Ok();
        }

        [AdminAuthorization]
        [HttpDelete("{id}")]
        public IActionResult RemoveOfficial(string id)
        {
            officialService.Remove(new Guid(id));
            return Ok();
        }

        [AdminAuthorization]
        [HttpPut]
        public IActionResult EditOfficial(EditOfficialRequest request)
        {
            officialService.Edit(new Official
            {
                Address = request.Address,
                Email = request.Email,
                Id = new Guid(request.Id),
                Pesel = request.Pesel,
                AuthorityId = new Guid(request.AuthorityId),
                CreatedDate = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                LastModifiedDate = DateTime.Now
            });
            return Ok();
        }

        [AdminAuthorization]
        [HttpGet("{id}")]
        public ActionResult<GetOfficialResponse> GetOfficial(string id)
        {
            var official = officialService.Get(new Guid(id));
            return official switch
            {
                null => NotFound("Official with given ID not found"),
                not null => Ok(new GetOfficialResponse
                {
                    Address = official.Address,
                    Email = official.Email,
                    Id = official.Id.ToString(),
                    Pesel = official.Pesel,
                    AuthorityId = official.AuthorityId.ToString(),
                    FirstName = official.FirstName,
                    LastName = official.LastName,
                    PhoneNumber = official.PhoneNumber
                })
            };

        }

        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpGet("{id}/complaints")]
        public ActionResult<IEnumerable<GetOfficialComplaintResponse>> GetOfficialComplaints(string id)
        {
            var official = officialService.Get(new Guid(id));
            return official switch
            {
                null => NotFound("Official with given ID not found"),
                not null => Ok(complaintService.GetOfficialComplaints(official.Id))
            };
        }

        [AdminAuthorization]
        [HttpGet("/authority/{id}/officials")]
        public ActionResult<IEnumerable<GetOfficialResponse>> GetOfficials(string id)
        {
            var authority = authorityService.Get(new Guid(id));
            return authority switch
            {
                null => NotFound("Authority with the given ID not found"),
                not null => Ok(authority.Officials.Select(x => new GetOfficialResponse
                {
                    Address = x.Address,
                    Email = x.Email,
                    Id = x.Id.ToString(),
                    Pesel = x.Pesel,
                    AuthorityId = x.AuthorityId.ToString(),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber
                }))
            };
        }

        [OfficialAuthorization]
        [AdminAuthorization]
        [HttpPost("/officialComplaint")]
        public IActionResult UpdateComplaint(UpdateComplaintRequest request)
        {
            this.complaintLogService.Add(new ComplaintLog
            {
                ComplaintId = new Guid(request.ComplaintId),
                Status = request.Status,
                OfficialId = this.userContext.Id
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
                    History = result.ComplaintLogs.Select(x => new GetComplaintLogResponse
                    {
                        Status = x.Status,
                        ComplaintId = x.ComplaintId.ToString(),
                        OfficialId = x.OfficialId.ToString(),
                        OfficialName = $"{x.Official.FirstName} {x.Official.LastName}",
                        UpdateDate = x.UpdateTime
                    })
                })
            };
        }
    }
}
