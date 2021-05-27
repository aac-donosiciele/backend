using DonosServer.API.DTOs.Requests;
using DonosServer.API.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DonosServer.API.Controllers
{
    [ApiController]
    [Route("/officials")]
    public class OfficialsController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddOfficial(AddOfficialRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOfficial(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult EditOfficial(EditOfficialRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<GetOfficialResponse> GetOfficial(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/complaints")]
        public ActionResult<IEnumerable<GetOfficialComplaintResponse>> GetOfficialComplaints(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/authority/{id}/officials")]
        public ActionResult<IEnumerable<GetOfficialResponse>> GetOfficials(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/officialComplaint")]
        public IActionResult AssignComplaint(AssignComplaintRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
