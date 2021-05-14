using System;
using System.Collections.Generic;


namespace Core.Entities
{
    class Official : BaseModel
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public Guid AuthorityId { get; set; }
        public OfficialRole Role { get; set; }

        public virtual ICollection<ComplaintLog> ComplaintLogs { get; set; } = new HashSet<ComplaintLog>();
    }
}
