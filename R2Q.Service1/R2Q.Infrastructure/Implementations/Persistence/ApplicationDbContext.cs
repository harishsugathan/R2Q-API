using Microsoft.EntityFrameworkCore;
using R2Q.Domain.Entities;

namespace R2Q.Infrastructure.Implementations.Persistence
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> vendor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vendor>
               (e =>
               {
                   e.HasNoKey();
               });
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }

}
