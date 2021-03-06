using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services.BasicCrudServices;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Infrastructure.Services
{
    public class ComplaintLogService : CreateService<ComplaintLog>, IComplaintLogService
    {
        public ComplaintLogService(DonosContext context) : base(context)
        {
        }

        public void CancelComplaint(Guid complaintId)
        {
            var complaintLog = this.DbContext.ComplaintsLogs.Find(complaintId);
            if(complaintLog is not null)
            {
                if(complaintLog.Status == DetailedComplaintStatus.Pending)
                {
                    // to change if it isnt working
                    complaintLog.LastModifiedDate = complaintLog.CreatedDate;
                    complaintLog.Status = DetailedComplaintStatus.Canceled;
                    this.DbSet.Add(complaintLog);
                    this.DbContext.SaveChanges();
                }
            }
        }
        public IEnumerable<ComplaintLog> GetComplaintLogs(Guid id)
        {
            return this.DbContext.ComplaintsLogs.Where(x => x.ComplaintId == id).ToList();
        }
        
    }
}
