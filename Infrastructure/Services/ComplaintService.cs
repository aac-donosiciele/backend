using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services
{
    public class ComplaintService : CUDService<Complaint>, IComplaintService
    {
        public ComplaintService(Donos_Context context) : base(context)
        {
        }

        public IEnumerable<Complaint> GetOfficialComplaints(Guid officialId)
        {
            var complaintsToGet = this.context.ComplaintsLogs
                                    .Where(cl => cl.OfficialId == officialId)
                                    .Include(cl => cl.Complaint)
                                    .Select(cl => cl.Complaint.Id)
                                    .ToHashSet();
            return this.context.Complaints.Where(c => complaintsToGet.Contains(c.Id))
                                          .Include(c0 => c0.ComplaintLogs).ToList();
        }

        public IEnumerable<Complaint> GetUserComplaints(Guid userId)
        {
           return this.context.Complaints.Where(c => c.SenderId == userId)
                                        .Include(c0 => c0.ComplaintLogs)
                                        .ToList();
        }
    }
}
