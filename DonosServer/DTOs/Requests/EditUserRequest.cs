namespace DonosServer.API.DTOs.Requests
{
    public class EditUserRequest
    {
        public string Id { get; set; }
        public string Pesel { get; set; }
        public bool Verified { get; set; }
    }
}
