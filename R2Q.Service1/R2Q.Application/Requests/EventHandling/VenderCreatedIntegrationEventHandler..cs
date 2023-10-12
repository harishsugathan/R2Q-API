using R2Q.Application.IntegrationEvents;
using R2Q.Common.Application.Contracts.DaprService.EventBus;

namespace R2Q.Application.Requests.EventHandling
{
    public class VenderCreatedIntegrationEventHandler
    : IIntegrationEventHandler<VenderCreatedIntegrationEvent>
    {

        public VenderCreatedIntegrationEventHandler()
        {
            
        }

        public Task Handle(VenderCreatedIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
