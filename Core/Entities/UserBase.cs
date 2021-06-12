namespace Core.Entities
{
    public abstract class UserBase : BaseModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
