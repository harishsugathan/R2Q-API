using System.Threading;
using System.Threading.Tasks;
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
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        DbSet<Vendor> Vendor { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>
        /// The user roles.
        /// </value>
        DbSet<UserRole> UserRoles { get; set; }

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
