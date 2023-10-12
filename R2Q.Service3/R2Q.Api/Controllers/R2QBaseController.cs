using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace R2Q.Service1.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public abstract class R2QBaseController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }


}
