using Core.Entities;
using System;

namespace Core.Interfaces.BasicCrudServices
{
    public interface IRead<T>
        where T : BaseModel
    {
        T Get(Guid id);
    }
}
