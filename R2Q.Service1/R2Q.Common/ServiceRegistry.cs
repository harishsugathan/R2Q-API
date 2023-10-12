
using Microsoft.Extensions.DependencyInjection;
using R2Q.Domain.Entities;
using R2Q.Common.Application.Contracts.Localization;
using R2Q.Common.Infrastructure.Implementations.Localization;
using Microsoft.Extensions.Configuration;
using R2Q.Common.Application.Contracts.DaprService;
using R2Q.Common.Infrastructure.Implementations.DaprServices;
using R2Q.Common.Infrastructure.Implementations.DaprServices.EventBus;
using R2Q.Common.Application.Contracts.DaprService.EventBus;

namespace R2Q.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddCommonServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<IEventBus, DaprEventBus>();
            services.AddScoped<IInvokeService, InvokeService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            return services;
        
        }

    }
}
