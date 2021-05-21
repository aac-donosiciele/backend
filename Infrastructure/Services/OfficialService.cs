using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class OfficialService : CRUDService<Official>, IOfficialService
    {
        public OfficialService(DonosContext context) : base(context)
        {
        }

    public IEnumerable<Official> GetAll(Guid id)
        {
            return this.DbContext.Officials.Where(o => o.AuthorityId == id).ToList();
        }
    }
}
