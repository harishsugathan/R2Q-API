using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R2Q.Domain.Entities;

namespace R2Q.Infrastructure.Implementations.Persistence.EntityConfigurations
{
    /// <summary>
    /// Defines the entity configuration for the IdentityRole entity
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{Role}" />
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.Property(x => x.IsVisibleToUsers)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
