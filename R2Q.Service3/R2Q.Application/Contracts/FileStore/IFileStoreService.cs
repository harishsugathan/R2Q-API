using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using R2Q.Application.Dtos.File;

namespace R2Q.Application.Contracts.FileStore
{
    /// <summary>
    /// Interface that defines the necessary methods for a File Store Service implementation
    /// </summary>
    public interface IFileStoreService
    {
        /// <summary>
        /// Uploads the local file.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="localPath">The local path.</param>
        /// <returns></returns>
        Task<string> UploadLocalFileAsync(string directoryName, string fileName, string localPath);

        /// <summary>
        /// Uploads the byte array.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="byteArray">The byte array.</param>
        /// <returns></returns>
        Task<string> UploadByteArrayAsync(string directoryName, string fileName, byte[] byteArray);

        /// <summary>
        /// Uploads the file stream.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="fileStream">The file stream.</param>
        /// <returns></returns>
        Task<string> UploadFileStreamAsync(string directoryName, string fileName, Stream fileStream);

        /// <summary>
        /// Uploads the base64 string.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="base64String">The base64 string.</param>
        /// <returns></returns>
        Task<string> UploadBase64StringAsync(string directoryName, string fileName, string base64String);

        /// <summary>
        /// Gets the pre-signed download URL.
        /// </summary>
        /// <param name="fileUrl">The file URL.</param>
        /// <param name="useSlidingExpiration">if set to <c>true</c> [use sliding expiration].</param>
        /// <param name="expiryTimeInMinutes">The expiry time in minutes.</param>
        /// <returns></returns>
        string GetPreSignedDownloadUrl(string fileUrl, bool useSlidingExpiration = false, double expiryTimeInMinutes = 10);

        /// <summary>
        /// Gets file size(bytes) from the URL 
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        Task<long> GetFileSizeAsync(string fileUrl);

        /// <summary>
        /// Method for getting pre-signed upload URL
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="subDirectoryInBucket"></param>
        /// <param name="requestHeaders"></param>
        /// <param name="expiryTimeInMinutes"></param>
        /// <returns></returns>
        PresignedUploadUrlResponse GetPreSignedUploadUrl(string fileName, string subDirectoryInBucket, Dictionary<string, string> requestHeaders, double expiryTimeInMinutes = 10);

        /// <summary>
        /// Copy file in s3
        /// </summary>
        /// <param name="sourceFileUrl"></param>
        /// <param name="destinationDirectory"></param>
        /// <param name="destinationFileName"></param>
        /// <param name="newFileTags"></param>
        /// <returns></returns>
        Task<string> CopyFileAsync(string sourceFileUrl, string destinationDirectory, string destinationFileName, Dictionary<string, string> newFileTags);

        /// <summary>
        /// Gets the pre-signed file URL expiry time.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        DateTime GetPreSignedFileUrlExpiryTime(DateTime dateTime);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="fileUrl">The file URL.</param>
        /// <returns></returns>
        Task<bool> DeleteFileAsync(string fileUrl);

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name="fileUrl">The file URL.</param>
        /// <returns></returns>
        Task<Stream> GetFileStreamAsync(string fileUrl);

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="thumbnail">if set to <c>true</c> [thumbnail].</param>
        /// <returns></returns>
        Task<List<string>> GetAllFilesAsync(string path, bool thumbnail = false);

        /// <summary>
        /// Deletes all attachments.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        Task<bool> DeleteAllFilesAsync(string path);

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        string GetFileUrl(string path);
    }
}
