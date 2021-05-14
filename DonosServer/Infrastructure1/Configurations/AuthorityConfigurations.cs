using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class AuthorityConfigurations : IEntityTypeConfiguration<Authority>
    {
        public void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(12).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(255).IsRequired();
            builder.Property(a => a.MaxOfficials).HasDefaultValue(10).IsRequired();
            builder.HasIndex(a => a.Id);
        }
    }
}
