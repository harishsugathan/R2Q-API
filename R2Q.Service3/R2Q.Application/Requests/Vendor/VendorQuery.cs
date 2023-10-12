
using R2Q.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using R2Q.Application.Dtos;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.Contracts.DaprService;

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
        private readonly IDaprService dapr;
        public VendorQueryHandler(IConfiguration configuration, IDaprService dapr)
        {
            this.configuration = configuration;
            this.dapr = dapr;
        }
        public async Task<ResponseDto<VendorDto>> Handle(VendorQuery request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<VendorDto>();
            try
            {
                var result = dapr.InvokeOtherServiceAsync<IEnumerable<string>>(HttpMethod.Get, "r2q-service2", "/health/ping");


            }
            catch (Exception ex)
            {
            }
            return responseDto;
        }
    }

}
