using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class ComplaintConfigurations : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TargetFirstName).HasMaxLength(50);
            builder.Property(c => c.TargetLastName).HasMaxLength(50);
            builder.Property(c => c.SendTime);
            builder.HasIndex(c => c.Id);

            builder.HasOne(c => c.Sender)
                    .WithMany(u => u.Complaints)
                    .HasForeignKey(c => c.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
