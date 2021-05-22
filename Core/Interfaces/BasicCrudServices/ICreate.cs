using Core.Entities;

namespace Core.Interfaces.BasicCrudServices
{
    public interface ICreate<T>
        where T : BaseModel
    {
        T Add(T entity);
    }
}
