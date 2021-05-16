using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class AuthorityService : CUDService<Authority>, IAuthorityService
    {
        public AuthorityService(Donos_Context context) : base(context)
        {
        }

        public IEnumerable<Authority> GetAll(ComplaintCategory category)
        {
            return this.context.Authorities.Where(a => a.Category == category).ToList();
        }
    }
}
