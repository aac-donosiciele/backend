using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class OfficialConfigurations : IEntityTypeConfiguration<Official>
    {
        public void Configure(EntityTypeBuilder<Official> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.Id);
            builder.HasOne(o => o.Authority)
                .WithMany(a => a.Officials)
                .HasForeignKey(o => o.AuthorityId);
        }
    }
}
