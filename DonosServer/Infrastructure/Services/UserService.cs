using Core.Entities;
using Core.Interfaces;
using System;

namespace Infrastructure.Services
{
    public class UserService : CUDService<User>, IUserService
    {
        public UserService(Donos_Context context) : base(context)
        {
        }

        public User Get(Guid id)
        {
            return this.dbSet.Find(id);
        }
    }
}
