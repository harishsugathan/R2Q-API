using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace R2Q.Service1.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
