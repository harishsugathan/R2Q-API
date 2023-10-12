using Microsoft.AspNetCore.Identity;

namespace R2Q.Domain.Entities
{
    public class UserRole: IdentityUserRole<string>
    {
        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public Role Role { get; set; }
    }
}
