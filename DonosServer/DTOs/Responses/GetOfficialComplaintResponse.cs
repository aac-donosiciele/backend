﻿using Core.Entities;
using System;

namespace DonosServer.API.DTOs.Responses
{
    public class GetOfficialComplaintResponse
    {
        public string Id { get; set; }
        public ComplaintCategory Category { get; set; }
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string TargetAddress { get; set; }
        public DateTime SendDate { get; set; }
        public string Note { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
