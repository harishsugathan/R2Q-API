using Dapr;
using Dapr.Client.Autogen.Grpc.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.Dtos;
using R2Q.Application.IntegrationEvents;
using R2Q.Application.Requests.Vendor;
using R2Q.Application.Requests.EventHandling;

namespace R2Q.Service1.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IntegrationEventController : R2QBaseController
    {
        private const string DAPR_PUBSUB_NAME = "r2qdapr-pubsub";

        [HttpPost("CreateVendorEvent")]
        [Topic(DAPR_PUBSUB_NAME, nameof(VenderCreatedIntegrationEvent))]
        public Task HandleAsync(
        VenderCreatedIntegrationEvent @event,
        [FromServices] VenderCreatedIntegrationEventHandler handler) =>
        handler.Handle(@event);

    }
}
