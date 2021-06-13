using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Configurations;

namespace Infrastructure
{
    public class DonosContext : DbContext
    {
        public DonosContext(DbContextOptions<DonosContext> options) : base(options)
        {
        }

        protected DonosContext()
        {
        }

        public DbSet<Official> Officials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintLog> ComplaintsLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddMockData();

            builder.ApplyConfiguration(new UserConfigurations());
            builder.ApplyConfiguration(new OfficialConfigurations());
            builder.ApplyConfiguration(new ComplaintConfigurations());
            builder.ApplyConfiguration(new ComplaintLogConfigurations());
        }
    }
}
