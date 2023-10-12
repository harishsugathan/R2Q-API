namespace R2Q.Infrastructure.Implementations.Email
{
    /// <summary>
    /// Defines the email configuration parameters
    /// </summary>
    public class EmailConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the sender address.
        /// </summary>
        /// <value>
        /// The sender address.
        /// </value>
        public string SenderAddress { get; set; }

        /// <summary>
        /// Gets or sets the SMTP host.
        /// </summary>
        /// <value>
        /// The SMTP host.
        /// </value>
        public string SmtpHost { get; set; }

        /// <summary>
        /// Gets or sets the SMTP port.
        /// </summary>
        /// <value>
        /// The SMTP port.
        /// </value>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets the SMTP username.
        /// </summary>
        /// <value>
        /// The SMTP username.
        /// </value>
        public string SmtpUsername { get; set; }

        /// <summary>
        /// Gets or sets the SMTP password.
        /// </summary>
        /// <value>
        /// The SMTP password.
        /// </value>
        public string SmtpPassword { get; set; }

        /// <summary>
        /// Gets or sets a value email is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if email is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmailEnabled { get; set; }
    }
}
