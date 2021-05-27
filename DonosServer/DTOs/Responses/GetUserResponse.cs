namespace DonosServer.API.DTOs.Responses
{
    public class GetUserResponse
    {
        public string Id { get; set; }
        public string Pesel { get; set; }
        public bool Verified { get; set; }
    }
}
