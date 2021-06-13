using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Complaint : BaseModel
    {
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string TargetAddress { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public DateTime SendTime { get; set; }
        public string Note { get; set; }

        public virtual ICollection<ComplaintLog> ComplaintLogs { get; set; } = new HashSet<ComplaintLog>();
    }
}
