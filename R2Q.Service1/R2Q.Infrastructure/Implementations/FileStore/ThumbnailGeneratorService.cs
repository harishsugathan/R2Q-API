using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using R2Q.Application.Contracts.FileStore;

namespace R2Q.Infrastructure.Implementations.FileStore
{
    /// <summary>
    /// Class with thumbnail generator methods.
    /// </summary>
    public class ThumbnailGeneratorService : IThumbnailGeneratorService
    {
        private readonly ImageThumbnailConfiguration thumbnailConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailGeneratorService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public ThumbnailGeneratorService(IConfiguration configuration)
        {
            thumbnailConfiguration = new ImageThumbnailConfiguration();
            configuration.GetSection(nameof(ImageThumbnailConfiguration))
                .Bind(thumbnailConfiguration);
        }

        public Task<Stream> GetGrayedThumbnailImageFromStreamAsync(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Stream GetThumbnailImageFromByteArray(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public Stream GetThumbnailImageFromFilePath(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetThumbnailImageFromFormFileAsync(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetThumbnailImageFromStreamAsync(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task SaveThumbnailImageToLocalPathAsync(Stream stream, string path)
        {
            throw new NotImplementedException();
        }
    }
}
