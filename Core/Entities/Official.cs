using System.Collections.Generic;

namespace Core.Entities
{
    public class Official : BaseModel
    {
        public virtual ICollection<ComplaintLog> ComplaintLogs { get; set; } = new HashSet<ComplaintLog>();
    }
}
