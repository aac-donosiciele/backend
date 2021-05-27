using Core.Entities;

namespace DonosServer.API.DTOs.Requests
{
    public class AssignComplaintRequest
    {
        public string OfficialId { get; set; }
        public string ComplaintId { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
