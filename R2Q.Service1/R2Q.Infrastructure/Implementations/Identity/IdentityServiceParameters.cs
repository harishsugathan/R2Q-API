namespace R2Q.Infrastructure.Implementations.Identity
{
    /// <summary>
    /// Defines the identity service parameters
    /// </summary>
    public class IdentityServiceParameters
    {
        /// <summary>
        /// Gets or sets the default user email.
        /// </summary>
        /// <value>
        /// The default user email.
        /// </value>
        public string DefaultAdminEmail { get; set; }

        /// <summary>
        /// Gets or sets the default user password.
        /// </summary>
        /// <value>
        /// The default user password.
        /// </value>
        public string DefaultAdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the first name of the default admin.
        /// </summary>
        /// <value>
        /// The first name of the default admin.
        /// </value>
        public string DefaultAdminFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the default admin.
        /// </summary>
        /// <value>
        /// The last name of the default admin.
        /// </value>
        public string DefaultAdminLastName { get; set; }

        /// <summary>
        /// Gets or sets the default admin location.
        /// </summary>
        /// <value>
        /// The default admin location.
        /// </value>
        public string DefaultAdminLocation { get; set; }

        /// <summary>
        /// Gets or sets the data protection token expiry in days.
        /// </summary>
        /// <value>
        /// The data protection token expiry in days.
        /// </value>
        public double DataProtectionTokenExpiryInDays { get; set; }
    }
}
