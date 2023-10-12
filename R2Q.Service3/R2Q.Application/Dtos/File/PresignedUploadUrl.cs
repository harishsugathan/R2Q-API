namespace R2Q.Application.Dtos.File
{
    /// <summary>
    /// Class that defines the PresignedUploadUrl
    /// </summary>
    public class PresignedUploadUrlResponse
    {
        /// <summary>
        /// Gets or sets PresignedUploadUrl
        /// </summary>
        public string PresignedUploadUrl { get; set; }

        /// <summary>
        /// Gets or sets FileUrl
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// Gets or sets PresignedThumbnailUploadUrl
        /// </summary>
        public string PresignedThumbnailUploadUrl { get; set; }

        /// <summary>
        /// Gets or sets ThumbnailFileUrl
        /// </summary>
        public string ThumbnailFileUrl { get; set; }

        /// <summary>
        /// Gets or sets FileName
        /// </summary>
        public string FileName { get; set; }
    }

}
