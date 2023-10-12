using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R2Q.Service1.Api.Controllers;
using System.Security.Claims;

namespace R2Q.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : BaseController
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetUserClaims()
        {
            var user = HttpContext.User;
            var userName = user.Identity.Name;
            var userRoles = user.FindAll(ClaimTypes.Role).Select(c => c.Value);

            // Your logic to use user claims

            return Ok(new { UserName = userName, Roles = userRoles });
        }
    }
}
