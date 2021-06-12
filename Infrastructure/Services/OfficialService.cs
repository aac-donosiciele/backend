using Core;
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

        IEnumerable<Official> IOfficialService.GetAll()
        {
            return this.DbContext.Officials.ToList();
        }

    }
}
