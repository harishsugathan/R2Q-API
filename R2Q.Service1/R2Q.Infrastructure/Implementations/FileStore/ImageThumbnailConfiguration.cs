namespace R2Q.Infrastructure.Implementations.FileStore
{
    /// <summary>
    /// A class with Image Thumbnail parameters
    /// </summary>
    public class ImageThumbnailConfiguration
    {
        /// <summary>
        /// Gets or sets the width in pixels.
        /// </summary>
        /// <value>
        /// The width in pixels.
        /// </value>
        public int WidthInPixels { get; set; }

        /// <summary>
        /// Gets or sets the height in pixels.
        /// </summary>
        /// <value>
        /// The height in pixels.
        /// </value>
        public int HeightInPixels { get; set; }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        public int Quality { get; set; }
    }
}
