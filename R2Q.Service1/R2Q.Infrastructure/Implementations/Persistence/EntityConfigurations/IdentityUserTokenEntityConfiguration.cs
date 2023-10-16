using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace R2Q.Infrastructure.Implementations.Persistence.EntityConfigurations
{
    /// <summary>
    /// Defines the entity configuration for the IdentityUserToken entity
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{IdentityUserToken}" />
    public class IdentityUserTokenEntityConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("user_tokens");
        }
    }
}
