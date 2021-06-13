using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IOfficialService : ICRUDService<Official>
    {
        IEnumerable<Official> GetAll();
    }
}
