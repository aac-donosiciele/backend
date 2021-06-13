using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserService : ICRUDService<User>
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByUsername(string username);

        IEnumerable<User> GetAll();
    }
}
