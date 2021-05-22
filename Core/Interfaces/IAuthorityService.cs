using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAuthorityService : ICRUDService<Authority>
    {
        IEnumerable<Authority> GetAll(ComplaintCategory category);
    }
}
