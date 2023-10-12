
using MediatR;
using Microsoft.Extensions.Logging;
using R2Q.Common.Application.Contracts.Localization;
using ApplicationException = R2Q.Common.Exceptions.ApplicationException;

namespace R2Q.Common.Application.Behaviors
{
    /// <summary>
    /// Defines the exception handling behavior
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// The localization service
        /// </summary>
        private readonly ILocalizationService localizationService;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="localizationService">The localization service</param>
        /// <param name="logger">The logger</param>
        public ExceptionHandlingBehavior(
            ILocalizationService localizationService,
            ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
        {
            this.localizationService = localizationService;
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
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ApplicationException ex)
            {
                ex.ExceptionMessage = ex.ExceptionMessageParameters != null ?
                    string.Format(localizationService.GetLocalizedString(ex.ExceptionMessage),
                    ex.ExceptionMessageParameters.ToArray()) : localizationService.GetLocalizedString(ex.ExceptionMessage);

                throw;
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                logger.LogError(ex, "Exception in Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
