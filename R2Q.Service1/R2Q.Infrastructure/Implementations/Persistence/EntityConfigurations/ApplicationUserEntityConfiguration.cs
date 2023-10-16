using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R2Q.Domain.Entities;

namespace R2Q.Infrastructure.Implementations.Persistence.EntityConfigurations
{
    /// <summary>
    /// Defines the entity configuration for the ApplicationUser entity
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{ApplicationUser}" />
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("application_users");
        }
    }
}
