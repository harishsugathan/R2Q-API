using Dapr;
using Dapr.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OpenTracing;
using R2Q.Application.Features.Vendor;
using R2Q.Service1.Api.Controllers;

namespace R2Q.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : BaseController
    {
        private readonly ILogger<VendorController> _logger;
        private readonly ITracer _tracer;
        public VendorController(ILogger<VendorController> logger,  ITracer tracer)
        {
            _logger = logger;
            _tracer = tracer;
        }
        /// <summary>
        /// CreateAccount
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("account/createvendor")]
        public async Task<IActionResult> CreateVendor(string name)
        {
            return Ok(await Mediator.Send(new VendorCommand { VendorName = name }));
        }


    }

}
