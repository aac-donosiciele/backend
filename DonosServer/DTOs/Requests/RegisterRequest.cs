namespace DonosServer.API.DTOs.Requests
{
    public class RegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Pesel { get; set; }
    }
}
