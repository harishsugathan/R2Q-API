using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace R2Q.Domain.Entities
{
    /// <summary>
    /// Defines the role entity
    /// </summary>
    /// <seealso cref="IdentityRole" />
    public class Role : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public Role()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public Role(string roleName) : base(roleName)
        {
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this role is visble to users.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this role is visible to users; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisibleToUsers { get; set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>
        /// The user roles.
        /// </value>
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
