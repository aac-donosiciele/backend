using DonosServer.API.DTOs.Requests;
using DonosServer.API.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DonosServer.API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        [HttpPut]
        public IActionResult EditUser(EditUserRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserResponse> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("complaints")]
        public IActionResult CreateComplaint(CreateComplaintRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/complaints")]
        public ActionResult<IEnumerable<GetUserComplaintResponse>> GetUserComplaints(string id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("complaints/{id}")]
        public IActionResult CancelComplaint(string id)
        {
            throw new NotImplementedException();
        }
    }
}
