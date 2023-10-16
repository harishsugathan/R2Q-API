using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R2Q.Domain.Entities;

namespace R2Q.Infrastructure.Implementations.Persistence.EntityConfigurations
{
    /// <summary>
    /// Defines the entity configuration for the IdentityUserRole entity
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{UserRole}" />
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_roles");

            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(x => x.Role).WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId).IsRequired();
        }
    }
}
