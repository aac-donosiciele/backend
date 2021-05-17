﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services.BasicCrudServices;
using System;

namespace Infrastructure.Services
{
    public class ComplaintLogService : CreateService<ComplaintLog>, IComplaintLogService
    {
        public ComplaintLogService(Donos_Context context) : base(context)
        {
        }

        public void CancelComplaint(Guid complaintId)
        {
            var complaintlog = this.context.ComplaintsLogs.Find(complaintId);
            if(complaintlog != null)
            {
                if (complaintlog.Status == DetailedComplaintStatus.Pending)
                {
                    // to change if it isnt working
                    complaintlog.LastModifiedDate = complaintlog.CreatedDate;
                    complaintlog.Status = DetailedComplaintStatus.Canceled;
                    this.dbSet.Add(complaintlog);
                    this.context.SaveChanges();
                }
            }
        }
    }
}