
using Dapr.Client;
using Microsoft.Extensions.Configuration;
using R2Q.Application.Contracts;
using R2Q.Application.Contracts.Vendor;
using R2Q.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Features.Vendor
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
        private readonly IConfiguration _configuration;
        public VendorCommandCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResponseDto<VendorDto>> Handle(VendorCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<VendorDto>();
            try
            {
               
            }
            catch
            {

            }
            return responseDto;
        }
    }
}
