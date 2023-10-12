
using Microsoft.Extensions.Configuration;
using R2Q.Application.Dtos;
using R2Q.Application.Dtos.Vendor;
using Microsoft.Extensions.Logging;
using R2Q.Common.Application.Contracts.DaprService;
using R2Q.Application.Contracts.Services;
using System.Net;

namespace R2Q.Application.Requests.Vendor
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorQuery : IRequest<ResponseDto<VendorDto>>
    {
        /// <summary>
        /// VendorName
        /// </summary>
        public int VendorId { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class VendorQueryHandler : IRequestHandler<VendorQuery, ResponseDto<VendorDto>>
    {
        /// <summary>
        /// The Configuration Service to access configurable keys and values
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<VendorQueryHandler> logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="dapr"></param>
        /// <param name="logger"></param>
        public VendorQueryHandler(IConfiguration configuration, ITripService tripService, ILogger<VendorQueryHandler> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseDto<VendorDto>> Handle(VendorQuery request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<VendorDto>();

            var response = "";

            if (response != null)
            {
                responseDto.Content = new VendorDto();
                responseDto.Content.Name = response.ToString();

            }
            return responseDto;
        }
    }

}
