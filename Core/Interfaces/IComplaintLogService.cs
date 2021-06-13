using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IComplaintLogService : ICreate<ComplaintLog>
    {
        void CancelComplaint(Guid complaintId);
        IEnumerable<ComplaintLog> GetComplaintLogs(Guid id);
    }
}
