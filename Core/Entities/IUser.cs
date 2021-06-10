namespace Core.Entities
{
    public interface IUser
    {
        string Username { get; set; }
        string PasswordHash { get; set; }
        Role Role { get; set; }
    }
}
