using Core.Entities;

namespace DonosServer.API.DTOs.Requests
{
    public class UpdateComplaintRequest
    {
        public string ComplaintId { get; set; }
        public string OfficialId { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
