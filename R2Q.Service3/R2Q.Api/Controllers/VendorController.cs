
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OpenTracing;
using R2Q.Application.Dtos.Vendor;
using R2Q.Application.Requests.Vendor;
using R2Q.Service1.Api.Controllers;

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
        [HttpGet("vendor/getvendor1")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var response = await Mediator.Send(new VendorQuery { VendorId = id });
            return Ok(response);
        }
        [Topic("r2qdapr-pubsub", "Service3-VenderPub")]
        [HttpPost("vendor/VenderPub")]
        public async Task<IActionResult> VenderPub([FromBody] VendorDto data)
        {
            return Ok(new { Message = "Data received successfully!", Data = data });
        }
    }

}
