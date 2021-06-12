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

        IEnumerable<Official> IOfficialService.GetAll(Guid id)
        {
            return this.DbContext.Officials.Where(o => o.AuthorityId == id).ToList();
        }

        public Official GetByUsernameAndPassword(string username, string password)
        {
            return this.DbContext.Officials.SingleOrDefault(x => x.Username == username && x.PasswordHash == Toolbox.ComputeHash(password));
        }
    }
}
