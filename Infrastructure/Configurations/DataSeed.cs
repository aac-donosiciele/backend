using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    internal static class DataSeed
    {
        public static void AddMockData(this ModelBuilder builder)
        {
            User tmp = new User()
            {
                IsVerified = true,
                Id = System.Guid.NewGuid(),
                Pesel = "112345678",
                Username = "megaAdmin",
                PasswordHash = Toolbox.ComputeHash("dupa1"),
                Role = Role.Admin

            };
            User tmp2 = new User()
            {
                IsVerified = true,
                Id = System.Guid.NewGuid(),
                Pesel = "012345678",
                Username = "megaAdmin12",
                PasswordHash = Toolbox.ComputeHash("dupa12"),
                Role = Role.User

            };
            User tmp3 = new User()
            {
                IsVerified = true,
                Id = System.Guid.NewGuid(),
                Pesel = "012345690",
                Username = "megaAdmin123",
                PasswordHash = Toolbox.ComputeHash("dupa123"),
                Role = Role.Official

            };
            builder.Entity<User>().HasData(new[] { tmp, tmp2, tmp3 });

            Official of1 = new Official()
            {
                Id = tmp.Id,
                Category = ComplaintCategory.Policja
            };

            Official of2 = new Official()
            {
                Id = tmp2.Id,
                Category = ComplaintCategory.PanstwowaInspekcjaPracy

            };
            builder.Entity<Official>().HasData(new[] { of1, of2 });
        }
    }
}
