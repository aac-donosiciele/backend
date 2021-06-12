using Core.Entities;

namespace DonosServer.API.DTOs.Requests
{
    public class UpdateComplaintRequest
    {
        public string ComplaintId { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
