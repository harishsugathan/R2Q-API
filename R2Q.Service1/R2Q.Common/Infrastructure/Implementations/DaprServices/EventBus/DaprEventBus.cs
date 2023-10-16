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
        string daprEndpoint = "http://localhost:3500";  // Replace with your actual Dapr endpoint

        var topicName = integrationEvent.GetType().Name;

        // Create an HttpClient configured with your custom Dapr endpoint
        using var customHttpClient = new HttpClient { BaseAddress = new Uri(daprEndpoint) };

        // Create a DaprClient instance by passing the custom HttpClient to DaprClientBuilder
        var daprClient = new DaprClientBuilder().UseHttpEndpoint("http://localhost:3500").Build();


        logger.LogInformation(
            "Publishing event {@Event} to {PubsubName}.{TopicName}",
            integrationEvent,
            Constants.pubSubName,
            topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        try
        {
            await daprClient.PublishEventAsync(Constants.pubSubName, topicName, (object)integrationEvent);
        }
        catch (Exception ex)
        {
            throw ex.InnerException;
        }

    }
}
