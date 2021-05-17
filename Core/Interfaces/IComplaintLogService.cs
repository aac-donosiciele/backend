using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using System;

namespace Core.Interfaces
{
    public interface IComplaintLogService : ICreate<ComplaintLog>
    {
        void CancelComplaint(Guid complaintId);
    }
}
