using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class AuthorityService : CRUDService<Authority>, IAuthorityService
    {
        public AuthorityService(DonosContext context) : base(context)
        {
        }

        public IEnumerable<Authority> GetAll(ComplaintCategory category)
        {
            return this.DbContext.Authorities.Where(a => a.Category == category).ToList();
        }
    }
}
