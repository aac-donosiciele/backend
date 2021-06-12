using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Official : UserBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public Guid AuthorityId { get; set; }
        public Authority Authority { get; set; }

        public virtual ICollection<ComplaintLog> ComplaintLogs { get; set; } = new HashSet<ComplaintLog>();
        
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
