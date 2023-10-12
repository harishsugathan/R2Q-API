using System.Collections.Generic;
using R2Q.Domain.Enums;

namespace R2Q.Application.Contracts.Email
{
    /// <summary>
    /// Defines the contract for the email template reader
    /// </summary>
    public interface IEmailTemplateReader
    {
        /// <summary>
        /// Gets the HTML mail content
        /// </summary>
        /// <param name="templateType">Type of the template.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        string GetMailContent(EmailTemplateType templateType, Dictionary<EmailTemplatePlaceholder, string> arguments);
    }
}
