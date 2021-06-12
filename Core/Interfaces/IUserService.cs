using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService : ICRUDService<User>
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByUsername(string username);
    }
}
