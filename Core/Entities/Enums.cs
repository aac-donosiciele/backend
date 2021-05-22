namespace Core.Entities
{
    public enum ComplaintCategory
    {
        Policja,
        StrazMiejska,
        UrzadSkarbowy,
        GlownyInspektoratSanitarny,
        NadzorBudowlany,
        PanstwowaInspekcjaPracy,
        MiejskiOsrodekPomocySpolecznej
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
