using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IOfficialService : ICUDService<Official>, IRead<Official>
    {
        IEnumerable<Official> GetAll(Guid id);
    }
}
