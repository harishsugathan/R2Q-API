

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application.Dtos;
using R2Q.Application.Dtos.Vendor;

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

        public VendorCommandCommandHandler(IConfiguration configuration, ILogger<VendorCommandCommandHandler> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task<ResponseDto<VendorDto>> Handle(VendorCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<VendorDto>();

            logger.LogInformation("Vender Publish");

            responseDto.SuccessMessage = "Vender Publish";
            return responseDto;
        }
    }
}
