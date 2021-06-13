using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonosServer.API.DTOs.Responses
{
    public class GetUsers
    {
        public Guid Id { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
    }
}
