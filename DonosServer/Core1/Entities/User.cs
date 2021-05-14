using System.Collections.Generic;

namespace Core.Entities
{
    class User : BaseModel
    {
        public bool Verified { get; set; }
        public string Pesel { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>();
    }
}
