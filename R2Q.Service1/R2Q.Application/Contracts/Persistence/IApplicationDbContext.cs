using Microsoft.EntityFrameworkCore;
using R2Q.Domain.Entities;

namespace R2Q.Application.Contracts.Persistence
{
    /// <summary>
    /// Defines the interface for the Application DbContext
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the vendors.
        /// </summary>
        /// <value>
        /// The vendors.
        /// </value>
        DbSet<Vendor> Vendors { get; set; }

        /// <summary>
        /// Runs the migrations.
        /// </summary>
        /// <returns></returns>
        Task RunMigrations();

        /// <summary>
        /// Save the changes asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
