using R2Q.Common.Infrastructure.Implementations.DaprServices.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.IntegrationEvents
{

    public record VenderCreatedIntegrationEvent(
        Guid Id,
        string VendorId)
        : IntegrationEvent;
}
