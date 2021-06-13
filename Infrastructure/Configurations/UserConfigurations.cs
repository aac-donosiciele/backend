using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Pesel).HasMaxLength(11);
            builder.HasIndex(u => u.Id);

            builder.HasMany(u => u.Complaints)
                .WithOne(c => c.Sender)
                .HasForeignKey(u => u.SenderId);
        }
    }
}
