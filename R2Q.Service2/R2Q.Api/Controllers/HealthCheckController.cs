using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using R2Q.Api.Controllers;
using R2Q.Requests.HealthCheck;
using R2Q.Service1.Api.Controllers;

namespace R2Q.Service2.Api.Controllers
{
    /// <summary>
    /// Defines the health check APIs
    /// </summary>
    /// <seealso cref="R2QBaseController" />
    public class HealthCheckController : BaseController
    {
        
        /// <summary>
        /// Pings this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet("health/ping")]
        [ProducesResponseType(typeof(string), 200)]
        [AllowAnonymous]
        public async Task<string> Ping()
        {
            return ($"Pong @ {DateTime.UtcNow}");
        }
    }
}
