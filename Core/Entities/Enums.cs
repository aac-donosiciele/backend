namespace Core.Entities
{
    public enum ComplaintCategory
    {
        Policja,
        StrazMiejska,
        UrzadSkarbowy,
        GlowntInspektoratSanitarny,
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
