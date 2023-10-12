using System.Threading;
using System.Threading.Tasks;
using R2Q.Application.Dtos.PublishSubscribeNotification;

namespace R2Q.Application.Contracts.PublishSubscribeNotification
{
    /// <summary>
    /// Defines the interface for the notification service
    /// </summary>
    public interface IPubSubNotificationService
    {
        /// <summary>
        /// Publishes the notification.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="messageDto">The message dto.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task PublishNotificationAsync(string topicName, PubSubMessageDto messageDto, CancellationToken cancellationToken);
    }
}
