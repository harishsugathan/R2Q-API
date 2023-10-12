using System.Collections.Generic;
using System.IO;
using R2Q.Application.Contracts.Email;
using R2Q.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using R2Q.Infrastructure.Constants;

namespace R2Q.Infrastructure.Implementations.Email
{
    /// <summary>
    /// Implements the email template reader
    /// </summary>
    internal class HtmlTemplateReader : IEmailTemplateReader
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        /// <summary>
        /// email template reader
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public HtmlTemplateReader(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Gets the HTML mail content
        /// </summary>
        /// <param name="templateType">Type of the template.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public string GetMailContent(
            EmailTemplateType templateType,
            Dictionary<EmailTemplatePlaceholder, string> arguments)
        {
            var contentRootPath = hostingEnvironment.ContentRootPath;
            var templatePath = contentRootPath + InfraConstants.EmailTemplatesPath;
            var emailBody = ReadTemplateFile(templatePath, InfraConstants.EmailHeaderTemplateFileName) +
                ReadTemplateFile(templatePath, $"{templateType}{InfraConstants.HtmlFileExtension}") +
                ReadTemplateFile(templatePath, InfraConstants.EmailFooterTemplateFileName);
            emailBody = emailBody.Replace("$$ContentPath$$", templatePath);
            return PopulateBodyArguments(emailBody, arguments);
        }

        /// <summary>
        /// Reads the template file.
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>template content</returns>
        private static string ReadTemplateFile(string templatePath, string fileName)
        {
            string fileContent = null;
            var path = templatePath + fileName;
            if (File.Exists(path))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(@path, FileMode.Open);
                    using var reader = new StreamReader(fs);
                    fs = null;
                    fileContent = reader.ReadToEnd();
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }

            return fileContent;
        }

        /// <summary>
        /// Populates the body arguments.
        /// </summary>
        /// <param name="emailBody">The email body.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        private static string PopulateBodyArguments(
            string emailBody,
            Dictionary<EmailTemplatePlaceholder, string> arguments)
        {
            foreach (var keyValuePair in arguments)
            {
                var placeholderKey = GetPlaceholderKey(keyValuePair.Key);
                emailBody = emailBody.Replace(placeholderKey, keyValuePair.Value);
            }

            return emailBody;
        }

        /// <summary>
        /// Gets the placeholder key.
        /// </summary>
        /// <param name="placeholder">The placeholder.</param>
        /// <returns></returns>
        private static string GetPlaceholderKey(EmailTemplatePlaceholder placeholder)
        {
            return $"$${placeholder}$$";
        }
    }

}
