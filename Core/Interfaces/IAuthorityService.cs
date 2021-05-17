using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAuthorityService : ICUDService<Authority>, ICreate<Authority>
    {
        IEnumerable<Authority> GetAll(ComplaintCategory category);
    }
}
