using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using R2Q.Infrastructure.Constants;
using R2Q.Infrastructure.Implementations.Persistence;
using R2Q.Infrastructure.Implementations.Orm;
using R2Q.Application.Contracts.Orm;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using R2Q.Application.Contracts.Identity;
using R2Q.Domain.Entities;
using R2Q.Infrastructure.Implementations.Identity;
using R2Q.Application.Contracts.Email;
using R2Q.Application.Contracts.Encryption;
using R2Q.Application.Contracts.FileStore;
using R2Q.Application.Contracts.Http;
using R2Q.Infrastructure.Implementations.Email;
using R2Q.Infrastructure.Implementations.Encryption;
using R2Q.Infrastructure.Implementations.FileStore;
using R2Q.Infrastructure.Implementations.Http;
using R2Q.Application.Contracts.PublishSubscribeNotification;
using R2Q.Infrastructure.Implementations.PublishSubscribeNotification;
using Microsoft.Identity.Web;
using R2Q.Common.Application.Contracts.Localization;
using R2Q.Common.Infrastructure.Implementations.Localization;
using R2Q.Application.Contracts.Services;
using R2Q.Infrastructure.Implementations.Services;

namespace R2Q.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration[InfraConstants.connectionString]));

            services.AddScoped<IOrmService, RepoDbOrm>();

            var connectionString = configuration.GetConnectionString(InfraConstants.CacheConnectionStringKey);
            services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

            services.AddScoped<IRequestContext, RequestContext>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailTemplateReader, HtmlTemplateReader>();
            services.AddSingleton<IEncryptionService, AesEncryptionService>();
            services.AddScoped<IThumbnailGeneratorService, ThumbnailGeneratorService>();
            services.AddScoped<IPubSubNotificationService, NotificationService>();
            AddCustomApplicationServices(services);
            AddLocalizationService(services);
            AddIdentityService(services, configuration);
            return services;
        }
        public static void AddCustomApplicationServices(IServiceCollection services)
        {
            services.AddSingleton<ITripService, TripService>(
  _ => new TripService(DaprClient.CreateInvokeHttpClient(InfraConstants.DaprSideCarService1, InfraConstants.DaprSideCarService1Endpoint)));

        }
        /// <summary>
        /// Adds the localization service.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddLocalizationService(IServiceCollection services)
        {
            var resourcesPath = Path.Combine(nameof(Implementations), nameof(Common.Infrastructure.Implementations.Localization));
            services.AddLocalization(options => options.ResourcesPath = resourcesPath);
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo(InfraConstants.EnglishUsCultureName),
                    };

                    options.DefaultRequestCulture = new RequestCulture(
                        culture: InfraConstants.EnglishUsCultureName,
                        uiCulture: InfraConstants.EnglishUsCultureName);

                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
                });

            services.AddScoped<ILocalizationService, LocalizationService>();
        }
        /// <summary>
        /// Adds the identity service.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddIdentityService(IServiceCollection services, IConfiguration configuration)
        {
            var identityServiceParameters = new IdentityServiceParameters();
            configuration.GetSection(nameof(IdentityService))
            .Bind(identityServiceParameters);

            // Set the data protection token expiry.
            // These are the tokens generated for password reset, email confirmation, etc.
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(identityServiceParameters.DataProtectionTokenExpiryInDays);
            });

            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

            services.AddScoped<IIdentityService, IdentityService>();
        }

    }
}
