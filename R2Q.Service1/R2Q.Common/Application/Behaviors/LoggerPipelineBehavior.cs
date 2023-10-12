using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace R2Q.Common.Application.Behaviors
{
    /// <summary>
    /// Defines a logger behavior
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="IPipelineBehavior{TRequest, TResponse}" />
    public class LoggerPipelineBehavior<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerPipelineBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Pipeline handler. Perform any additional behavior and await the <paramref name="next" /> delegate as necessary
        /// </summary>
        /// <param name="request">Incoming request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="next">Awaitable delegate for the next action in the pipeline.
        /// Eventually this delegate represents the handler.</param>
        /// <returns>
        /// Awaitable task returning the <typeparamref name="TResponse" />
        /// </returns>
        public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            logger.LogTrace($"Executing {typeof(TRequest).Name}.");
            var response = await next();
            logger.LogTrace($"Executed {typeof(TRequest).Name}.");
            return response;
        }
    }
}
