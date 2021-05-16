using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class OfficialService : CUDService<Official>, IOfficialService
    {
        public OfficialService(Donos_Context context) : base(context)
        {
        }

        public Official Get(Guid id)
        {
            return this.dbSet.Find(id);
        }

    public IEnumerable<Official> GetAll(Guid id)
        {
            return this.context.Officials.Where(o => o.AuthorityId == id).ToList();
        }
    }
}
