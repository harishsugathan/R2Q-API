using System.IO;
using Microsoft.AspNetCore.Http;
using R2Q.Common.Application.Constants;

namespace R2Q.Common.Extensions
{
    /// <summary>
    /// Defines the file extension methods
    /// </summary>
    internal static class FileExtensions
    {
        /// <summary>
        /// Convert image file to byte array.
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns></returns>
        internal static byte[] ConvertToByteArray(this IFormFile file)
        {
            byte[] imageDataArray;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imageDataArray = memoryStream.ToArray();
            }

            return imageDataArray;
        }

        /// <summary>
        /// Gets the name of the thumbnail file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        internal static string GetThumbnailFileName(this string fileName) => $"{Path.GetFileNameWithoutExtension(fileName)}_{Constants.ThumbnailImageSuffix}{Path.GetExtension(fileName)}";
    }
}
