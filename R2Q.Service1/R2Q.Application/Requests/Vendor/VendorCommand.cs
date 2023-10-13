

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application.Contracts.Services;
using R2Q.Application.Contracts.Services.Models;
using R2Q.Application.Dtos;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.IntegrationEvents;
using R2Q.Common.Application.Contracts.DaprService;
using R2Q.Common.Application.Contracts.DaprService.EventBus;
using System.Net;

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
        /// <summary>
        /// Authorization token
        /// </summary>
        public string Authorization { get; set; }


    }
    /// <summary>
    /// Vendor Command Handler
    /// </summary>
    public class VendorCommandCommandHandler : IRequestHandler<VendorCommand, ResponseDto<VendorDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ITripService tripService;
        /// <summary>
        /// The IConfiguration
        /// </summary>
        private readonly IConfiguration configuration;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<VendorCommandCommandHandler> logger;
        /// <summary>
        /// Event
        /// </summary>
        private readonly IEventBus eventBus;
        /// <summary>
        /// Event
        /// </summary>
        private readonly IStateService state;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="dapr"></param>
        /// <param name="logger"></param>
        public VendorCommandCommandHandler(ITripService tripService,IConfiguration configuration, ILogger<VendorCommandCommandHandler> logger, IEventBus eventBus, IStateService state)
        {
            this.tripService = tripService;
            this.configuration = configuration;
            this.tripService = tripService;
            this.logger = logger;
            this.eventBus = eventBus;
            this.state = state;
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

            // Get state
            //var result = state.GetStateAsync<string>("key");
            // Publish event
            //await eventBus.PublishAsync(eventMessage);

            // Invoke Service
            var tripData = new TripData();
            tripData.Items = new List<TripDataItem>();
            var tripDataDetails = new TripDataItem(1, "trip");
            tripData.Items.Add(tripDataDetails);
            var response = await tripService.GetAsync();
            responseDto.Content = new VendorDto();
            responseDto.Content.Name = response;
            return responseDto;
        }
    }
}
