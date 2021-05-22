using Core.Entities;
using Core.Interfaces.BasicCrudServices;

namespace Core.Interfaces
{
    public interface ICRUDService<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete
        where T : BaseModel
    {
    }
}
