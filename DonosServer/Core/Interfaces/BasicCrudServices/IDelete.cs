using System;

namespace Core.Interfaces.BasicCrudServices
{
    public interface IDelete
    {
        void Remove(Guid id);
    }
}
