namespace R2Q.Infrastructure.Implementations.Cache
{
    /// <summary>
    /// Defines the Cache Service parameters
    /// </summary>
    internal class CacheServiceParameters
    {
        /// <summary>
        /// Gets or sets the default expiry in seconds.
        /// </summary>
        /// <value>
        /// The default expiry in seconds.
        /// </value>
        public int DefaultExpiryInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the project item expiry in seconds.
        /// </summary>
        /// <value>
        /// The project item expiry in seconds.
        /// </value>
        public int ProjectItemExpiryInSeconds { get; set; }
    }
}
