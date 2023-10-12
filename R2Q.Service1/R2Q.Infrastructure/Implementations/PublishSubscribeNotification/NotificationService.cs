using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using R2Q.Application.Contracts.PublishSubscribeNotification;
using R2Q.Application.Dtos.PublishSubscribeNotification;

namespace R2Q.Infrastructure.Implementations.PublishSubscribeNotification
{
    /// <summary>
    /// Defines the implementation of the publish subscriber notification service using AWS SNS
    /// </summary>
    /// <seealso cref="IPubSubNotificationService" />
    internal class NotificationService : IPubSubNotificationService
    {
        private readonly ILogger<NotificationService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationService"/> class.
        /// </summary>
        /// <param name="amazonSns">The amazon SNS.</param>
        public NotificationService(
            ILogger<NotificationService> logger)
        {
            this.logger = logger;
        }

        public Task PublishNotificationAsync(string topicName, PubSubMessageDto messageDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
