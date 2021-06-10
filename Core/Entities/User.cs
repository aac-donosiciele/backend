using System.Collections.Generic;

namespace Core.Entities
{
    public class User : BaseModel, IUser
    {
        public bool IsVerified { get; set; }
        public string Pesel { get; set; }

        public virtual ICollection<Complaint> Complaints { get; set; } = new HashSet<Complaint>();
        
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
