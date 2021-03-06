using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IComplaintService : ICRUDService<Complaint>
    {
        IEnumerable<Complaint> GetUserComplaints(Guid userId);
        IEnumerable<Complaint> GetOfficialComplaints(Guid officialId);
    }
}
