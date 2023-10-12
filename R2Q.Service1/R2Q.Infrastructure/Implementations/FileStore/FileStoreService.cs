using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application.Contracts.FileStore;
using R2Q.Application.Dtos.File;

namespace R2Q.Infrastructure.Implementations.FileStore
{
    /// <summary>
    /// Defines the implementation of the File Store Service using Amazon S3
    /// </summary>
    public class FileStoreService : IFileStoreService
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStoreService" /> class.
        /// </summary>
        /// <param name="amazonS3">The amazon s3.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public FileStoreService(
            IConfiguration configuration,
            ILogger<FileStoreService> logger)
        {
            this.logger = logger;
        }

        public Task<string> CopyFileAsync(string sourceFileUrl, string destinationDirectory, string destinationFileName, Dictionary<string, string> newFileTags)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAllFilesAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFileAsync(string fileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllFilesAsync(string path, bool thumbnail = false)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetFileSizeAsync(string fileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetFileStreamAsync(string fileUrl)
        {
            throw new NotImplementedException();
        }

        public string GetFileUrl(string path)
        {
            throw new NotImplementedException();
        }

        public string GetPreSignedDownloadUrl(string fileUrl, bool useSlidingExpiration = false, double expiryTimeInMinutes = 10)
        {
            throw new NotImplementedException();
        }

        public DateTime GetPreSignedFileUrlExpiryTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public PresignedUploadUrlResponse GetPreSignedUploadUrl(string fileName, string subDirectoryInBucket, Dictionary<string, string> requestHeaders, double expiryTimeInMinutes = 10)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadBase64StringAsync(string directoryName, string fileName, string base64String)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadByteArrayAsync(string directoryName, string fileName, byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadFileStreamAsync(string directoryName, string fileName, Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadLocalFileAsync(string directoryName, string fileName, string localPath)
        {
            throw new NotImplementedException();
        }
    }
}
