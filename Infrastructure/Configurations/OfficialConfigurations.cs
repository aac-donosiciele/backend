using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class OfficialConfigurations : IEntityTypeConfiguration<Official>
    {
        public void Configure(EntityTypeBuilder<Official> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.Id);

        }
    }
}
