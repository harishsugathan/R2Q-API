
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OpenTracing;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.Requests.Vendor;
using R2Q.Domain.Entities;
using R2Q.Service1.Api.Controllers;
using StackExchange.Redis;

namespace R2Q.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : R2QBaseController
    {
        /// <summary>
        /// Createvendor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("vendor/createvendor")]
        public async Task<IActionResult> CreateVendor(string name)
        {
            return Ok(await Mediator.Send(new VendorCommand { VendorName = name }));
        }
        /// <summary>
        /// Get vendor
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("vendor/getvendor")]
        public async Task<IActionResult> GetVendor()
        {
            var response = await Mediator.Send(new VendorQuery { VendorId = 1 });
            return Ok(response);
        }
    }

}
