using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace R2Q.Common.Application.Behaviors
{

    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;

        public PerformanceBehavior(ILogger<TRequest> logger)
        {
            this.timer = new Stopwatch();
            this.logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            timer.Start();
            var response = await next();
            timer.Stop();
            var elapsedMilliseconds = timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 1500)
            {
                var requestName = typeof(TRequest).Name;
                logger.LogWarning("Long Running Request: {RequestName} ({ElapsedMilliseconds} milliseconds) {@RequestBody}",
                    requestName,
                    elapsedMilliseconds,
                    request);
            }

            return response;
        }
    }
}