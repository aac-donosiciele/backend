using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IOfficialService : ICUDService<Official>, ICreate<Official>
    {
        IEnumerable<Official> GetAll(Guid id);
    }
}
