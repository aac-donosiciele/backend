namespace Core.Entities
{
    public enum ComplaintCategory
    {
        P,
        SM,
        US,
        GIS,
        NB,
        PIP,
        MOPS
    }
    public enum DetailedComplaintStatus
    {
        Pending,
        Canceled,
        Assigned,
        Rejected,
        InProgress,
        Finished
    }

    public enum OfficialRole
    {
        Official,
        Admin
    }
}
