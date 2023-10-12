using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace R2Q.Requests.HealthCheck
{
    /// <summary>
    /// Defines the query for a health check ping
    /// </summary>
    /// <seealso cref="IRequest{string}" />
    public class HealthCheckPingQuery : IRequest<string>
    {
    }

    /// <summary>
    /// Defines the handler for the health check ping query
    /// </summary>
    /// <seealso cref="IRequestHandler{HealthCheckPingQuery, string}" />
    public class HealthCheckPingQueryHandler : IRequestHandler<HealthCheckPingQuery, string>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<string> Handle(HealthCheckPingQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Service3 Pong @ {DateTime.UtcNow}");
        }
    }
}
