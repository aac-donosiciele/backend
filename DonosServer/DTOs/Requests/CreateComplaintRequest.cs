using Core.Entities;

namespace DonosServer.API.DTOs.Requests
{
    public class CreateComplaintRequest
    {
        public ComplaintCategory Category { get; set; }
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string TargetAddress { get; set; }
        public string SenderId { get; set; }
        public string Note { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
