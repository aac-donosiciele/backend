using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    class Complaint : BaseModel
    {
        public string TargetFristName { get; set; }
        public string TargetLastName { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public DateTime SendTime { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ComplaintLog> ComplaintLogs { get; set; } = new HashSet<ComplaintLog>();
    }
}
