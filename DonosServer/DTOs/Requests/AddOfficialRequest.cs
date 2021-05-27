using Core.Entities;

namespace DonosServer.API.DTOs.Requests
{
    public class AddOfficialRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public string AuthorityId { get; set; }
        public OfficialRole Role { get; set; }
    }
}
