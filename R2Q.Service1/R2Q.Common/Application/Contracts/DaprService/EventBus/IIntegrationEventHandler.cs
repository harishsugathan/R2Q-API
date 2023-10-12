

using R2Q.Common.Infrastructure.Implementations.DaprServices.EventBus;

namespace R2Q.Common.Application.Contracts.DaprService.EventBus;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler
{
}
