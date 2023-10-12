using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;
using R2Q.Common.Application.Behaviors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using R2Q.Application.Contracts.Services;

namespace R2Q.Application
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
