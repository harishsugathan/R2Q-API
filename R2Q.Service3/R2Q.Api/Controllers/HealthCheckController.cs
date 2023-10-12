using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using R2Q.Api.Controllers;
using R2Q.Application.Requests.HealthCheck;
using R2Q.Requests.HealthCheck;

namespace R2Q.Service1.Api.Controllers
{
    /// <summary>
    /// Defines the health check APIs
    /// </summary>
    /// <seealso cref="R2QBaseController" />
    public class HealthCheckController : R2QBaseController
    {
        
        /// <summary>
        /// Pings this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("health/ping")]
        [ProducesResponseType(typeof(string), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> Ping()
        {
            var query = new HealthCheckPingQuery();
            return Ok(await Mediator.Send(query));
        }
        [HttpGet("health/heartbeats")]
        [ProducesResponseType(typeof(string), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> heartbeats()
        {
            var query = new HeartbeatsQuery();
            return Ok(await Mediator.Send(query));
        }

    }
}
