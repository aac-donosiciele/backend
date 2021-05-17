using Core.Entities;
using Core.Interfaces.BasicCrudServices;

namespace Core.Interfaces
{
    public interface ICUDService<T> : ICreate<T>, IUpdate<T>, IDelete
        where T : BaseModel
    {
    }
}
