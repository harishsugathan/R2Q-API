using System.Threading.Tasks;

namespace R2Q.Application.Contracts.Email
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the email asynchronously.
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="htmlEmailBody"></param>
        /// <param name="ccAddresses"></param>
        /// <param name="bccAddresses"></param>
        /// <returns></returns>
        Task SendEmailAsync(string toAddress, string subject, string htmlEmailBody, string[] ccAddresses = null, string[] bccAddresses = null);

        /// <summary>
        /// Sends the email asynchronously with multiple receipients.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="htmlEmailBody">The HTML email body.</param>
        /// <param name="ccAddresses">The cc addresses.</param>
        /// <param name="bccAddresses">The BCC addresses.</param>
        /// <returns></returns>
        Task SendEmailAsync(string[] toAddresses, string subject, string htmlEmailBody, string[] ccAddresses = null, string[] bccAddresses = null);
    }
}
