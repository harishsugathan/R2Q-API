

using R2Q.Common.Infrastructure.Implementations.DaprServices.EventBus;

namespace R2Q.Common.Application.Contracts.DaprService.EventBus;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent integrationEvent);
}
