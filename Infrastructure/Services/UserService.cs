using Core;
using Core.Entities;
using Core.Interfaces;
using System.Linq;

namespace Infrastructure.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        public UserService(DonosContext context) : base(context)
        {
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return this.DbContext.Users.SingleOrDefault(x => x.Username == username && x.PasswordHash == Toolbox.ComputeHash(password));
        }

        public User GetByUsername(string username)
        {
            return this.DbContext.Users.SingleOrDefault(x => x.Username == username);
        }
    }
}
