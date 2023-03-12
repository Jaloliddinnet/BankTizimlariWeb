using BankTizimlari.Domain.Entities.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTIzimlati.Data.BankDBContexts
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bank> banks { get; set; }
        public DbSet<ApiUser> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasData(
                    new Role
                    {
                        Id = Guid.Parse("1e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new Role
                    {
                        Id = Guid.Parse("2e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        Name = "BankAdmin",
                        NormalizedName = "BANKADMIN"
                    },
                    new Role
                    {
                        Id = Guid.Parse("3e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
            }
        }

        public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
        {
            public void Configure(EntityTypeBuilder<ApiUser> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new ApiUser
                    {
                        Id = Guid.Parse("4e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        FirstName = "Firdavs",
                        LastName = "Rustamov",
                        PassportSery = "AC2654123",
                        PhoneNumber = "+998915115341",
                        Region = "Bukhara",
                        NormalizedUserName = "Ferdavs",
                        PasswordHash = hasher.HashPassword(null, "Ferdavs8#")
                    },
                    new ApiUser
                    {
                        Id = Guid.Parse("5e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        FirstName = "Jaloliddin",
                        LastName = "Axmedov",
                        PassportSery = "AC2995341",
                        PhoneNumber = "+998910199897",
                        Region = "Samakand",
                        NormalizedUserName = "Jaloliddin",
                        PasswordHash = hasher.HashPassword(null, "Jaloliddin1#")
                    },
                    new ApiUser
                    {
                        Id = Guid.Parse("6e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        FirstName = "Arislon",
                        LastName = "Qosimov",
                        PassportSery = "AC2694123",
                        PhoneNumber = "+998946575341",
                        Region = "Bukhara",
                        NormalizedUserName = "Arislon",
                        PasswordHash = hasher.HashPassword(null, "Arislon8#")
                    }

                );
            }
        }
        public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new IdentityUserRole<Guid>
                    {
                        UserId = Guid.Parse("5e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        RoleId = Guid.Parse("1e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec")
                    },
                    new IdentityUserRole<Guid>
                    {
                        UserId = Guid.Parse("6e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        RoleId = Guid.Parse("2e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec")
                    },
                    new IdentityUserRole<Guid>
                    {
                        UserId = Guid.Parse("4e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec"),
                        RoleId = Guid.Parse("3e6c2d6a-dc83-8bab-b7a9-98ae31ee16ec")
                    }

                );
            }
        }
    }
}
