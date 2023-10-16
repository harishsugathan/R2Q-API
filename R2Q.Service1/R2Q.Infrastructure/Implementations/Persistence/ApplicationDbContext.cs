using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using R2Q.Application.Contracts.Persistence;
using R2Q.Domain.Entities;
using System.Reflection;

namespace R2Q.Infrastructure.Implementations.Persistence
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(
                    i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                )
            );
        }

        /// <summary>
        /// Runs the migrations.
        /// </summary>
        public async Task RunMigrations()
        {
            await Database.MigrateAsync();
        }
    }

}
