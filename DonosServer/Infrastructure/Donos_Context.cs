using Microsoft.EntityFrameworkCore;
using System;
using Core.Entities;
using Infrastructure.Configurations;

namespace Infrastructure
{
    public class Donos_Context : DbContext
    {
        public Donos_Context(DbContextOptions<Donos_Context> options) : base(options)
        {
        }

        protected Donos_Context()
        {
        }

        public DbSet<Authority> Authorities { get; set; }
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
            builder.ApplyConfiguration(new AuthorityConfigurations());
        }
    }

}
}
