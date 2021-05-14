using System.Collections.Generic;

namespace Core.Entities
{
    class Authority : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxOfficials { get; set; }
        public virtual ICollection<Official> Officials { get; set; } = new HashSet<Official>();
    }
}
