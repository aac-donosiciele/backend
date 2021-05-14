using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    class ComplaintLog : BaseModel
    {
        public Guid OfficialId { get; set; }
        public Official Official { get; set; }
        public Guid  ComplaintId { get; set; }
        public Complaint Complaint { get; set; }
        public DateTime UpdateTime { get; set; }
        public DetailedComplaintStatus Status { get; set; }
    }
}
