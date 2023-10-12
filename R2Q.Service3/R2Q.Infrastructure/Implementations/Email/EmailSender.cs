using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application.Contracts.Email;
using R2Q.Infrastructure.Implementations.Email;

namespace R2Q.Infrastructure.Implementations.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;
        private readonly ILogger<EmailSender> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public EmailSender(
            IConfiguration configuration,
            ILogger<EmailSender> logger)
        {
            this.emailConfiguration = new EmailConfiguration();
            configuration.GetSection(nameof(EmailConfiguration))
                .Bind(emailConfiguration);

            this.logger = logger;
        }

        public Task SendEmailAsync(string toAddress, string subject, string htmlEmailBody, string[] ccAddresses = null, string[] bccAddresses = null)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailAsync(string[] toAddresses, string subject, string htmlEmailBody, string[] ccAddresses = null, string[] bccAddresses = null)
        {
            throw new NotImplementedException();
        }
    }
}
