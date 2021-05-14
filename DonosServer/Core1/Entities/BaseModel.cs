using System;


namespace Core.Entities
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public ComplaintCategory Category { get; set; }
    }
}
