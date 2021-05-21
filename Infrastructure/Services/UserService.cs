using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        public UserService(DonosContext context) : base(context)
        {
        }
    }
}
