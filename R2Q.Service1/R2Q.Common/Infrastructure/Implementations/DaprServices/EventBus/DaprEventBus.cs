using Microsoft.Extensions.Logging;
using R2Q.Common.Application.Constants;
using R2Q.Common.Application.Contracts.DaprService.EventBus;

namespace R2Q.Common.Infrastructure.Implementations.DaprServices.EventBus;

public class DaprEventBus : IEventBus
{
    private readonly DaprClient dapr;
    private readonly ILogger logger;

    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        this.dapr = dapr;
        this.logger = logger;
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        var topicName = integrationEvent.GetType().Name;

        logger.LogInformation(
            "Publishing event {@Event} to {PubsubName}.{TopicName}",
            integrationEvent,
            Constants.pubSubName,
            topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await dapr.PublishEventAsync(Constants.pubSubName, topicName, (object)integrationEvent);
    }
}
