using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class ComplaintLogConfigurations : IEntityTypeConfiguration<ComplaintLog>
    {
        public void Configure(EntityTypeBuilder<ComplaintLog> builder)
        {
            builder.HasKey(c => c.Id);         
            builder.HasIndex(c => new { c.ComplaintId, c.CreatedDate, c.OfficialId });
            builder.HasOne(c => c.Official)
                .WithMany(o => o.ComplaintLogs)
                .HasForeignKey(c => c.OfficialId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(cl => cl.Complaint)
                .WithMany(c => c.ComplaintLogs)
                .HasForeignKey(cl => cl.ComplaintId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
