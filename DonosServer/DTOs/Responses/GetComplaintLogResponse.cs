using Core.Entities;
using System;

namespace DonosServer.API.DTOs.Responses
{
    public class GetComplaintLogResponse
    {
        public DateTime UpdateDate { get; set; }
        public string OfficialId { get; set; }
        public string ComplaintId { get; set; }
        public string Status { get; set; }
    }
}
