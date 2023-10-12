

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application.Dtos;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.IntegrationEvents;
using R2Q.Common.Application.Contracts.DaprService.EventBus;

namespace R2Q.Application.Requests.Vendor
{
    /// <summary>
    /// Vendor
    /// </summary>
    public class VendorCommand : IRequest<ResponseDto<VendorDto>>
    {
        /// <summary>
        /// VendorName
        /// </summary>
        public string VendorName { get; set; }

    }
    /// <summary>
    /// Vendor Command Handler
    /// </summary>
    public class VendorCommandCommandHandler : IRequestHandler<VendorCommand, ResponseDto<VendorDto>>
    {
        /// <summary>
        /// The IConfiguration
        /// </summary>
        private readonly IConfiguration configuration;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<VendorCommandCommandHandler> logger;

        private readonly IEventBus eventBus;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="dapr"></param>
        /// <param name="logger"></param>
        public VendorCommandCommandHandler(IConfiguration configuration, ILogger<VendorCommandCommandHandler> logger, IEventBus eventBus)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.eventBus = eventBus;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseDto<VendorDto>> Handle(VendorCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<VendorDto>();

            var eventRequestId = Guid.NewGuid();

            var eventMessage = new VenderCreatedIntegrationEvent(eventRequestId, "1");

            // Once basket is checkout, sends an integration event to
            // ordering.api to convert basket to order and proceed with
            // order creation process
            await eventBus.PublishAsync(eventMessage);

            return responseDto;
        }
    }
}
