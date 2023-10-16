using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace R2Q.Infrastructure.Implementations.Persistence.EntityConfigurations
{
    /// <summary>
    /// Defines the entity configuration for the IdentityRoleClaim entity
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{IdentityRoleClaim}" />
    public class IdentityRoleClaimEntityConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
        {
            builder.ToTable("role_claims");
        }
    }
}
