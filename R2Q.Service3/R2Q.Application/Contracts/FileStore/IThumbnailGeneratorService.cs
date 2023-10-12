using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.FileStore
{
    /// <summary>
    /// Interface for thumbnail generator.
    /// </summary>
    public interface IThumbnailGeneratorService
    {
        /// <summary>
        /// Method to get thumbnail image from file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Stream GetThumbnailImageFromFilePath(string filePath);

        /// <summary>
        /// Method to get thumbnail image from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        Task<Stream> GetThumbnailImageFromStreamAsync(Stream stream);

        /// <summary>
        /// Method to get thumbnail image from form file
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<Stream> GetThumbnailImageFromFormFileAsync(IFormFile formFile);

        /// <summary>
        /// Method to get thumbnail image from byte array
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        Stream GetThumbnailImageFromByteArray(byte[] byteArray);

        /// <summary>
        /// Method to get grayed thumbnail image from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        Task<Stream> GetGrayedThumbnailImageFromStreamAsync(Stream stream);

        /// <summary>
        /// Method to save thumbnail image to local path
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        Task SaveThumbnailImageToLocalPathAsync(Stream stream, string path);
    }
}
