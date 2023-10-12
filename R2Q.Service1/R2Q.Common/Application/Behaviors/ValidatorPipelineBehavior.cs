using FluentValidation;
using MediatR;
using R2Q.Common.Application.Contracts.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = R2Q.Common.Exceptions.ValidationException;

namespace R2Q.Common.Application.Behaviors
{
    /// <summary>
    /// Defines the validation pipeline behavior
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="IPipelineBehavior{TRequest, TResponse}" />
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// The validators
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> validators;

        /// <summary>
        /// The localization service
        /// </summary>
        private readonly ILocalizationService localizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorPipelineBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The validators.</param>
        /// <param name="localizationService">The localization service</param>
        public ValidatorPipelineBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            ILocalizationService localizationService)
        {
            this.validators = validators;
            this.localizationService = localizationService;
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
        /// <exception cref="ValidationException"></exception>
        public Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            var failures = validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Count > 0)
            {
                foreach (var failure in failures)
                {
                    failure.ErrorMessage = localizationService.GetLocalizedString(failure.ErrorMessage);
                }

                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
