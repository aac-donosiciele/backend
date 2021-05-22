using Core.Entities;

namespace Core.Interfaces.BasicCrudServices
{
    public interface IUpdate<T>
        where T : BaseModel
    {
        T Edit(T entity);
    }
}
