using Core.Entities;

namespace DonosServer.API.DTOs.Responses
{
    public class LogInResponse
    {
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
