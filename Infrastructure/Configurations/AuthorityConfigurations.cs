using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class AuthorityConfigurations : IEntityTypeConfiguration<Authority>
    {
        public void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.PhoneNumber).HasMaxLength(12);
            builder.Property(a => a.Address).HasMaxLength(255);
            builder.Property(a => a.MaxOfficials).HasDefaultValue(10);
            builder.HasIndex(a => a.Id);
        }
    }
}
