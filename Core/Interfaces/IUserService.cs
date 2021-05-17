using Core.Entities;
using Core.Interfaces.BasicCrudServices;

namespace Core.Interfaces
{
    public interface IUserService : ICUDService<User>, IRead<User>
    {
    }
}
