using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using R2Q.Infrastructure.Constants;
using R2Q.Infrastructure.Implementations.Persistence;
using R2Q.Infrastructure.Implementations.Orm;
using R2Q.Application.Contracts.Orm;
using R2Q.Application.Contracts.Cache;
using R2Q.Infrastructure.Implementations.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using R2Q.Application.Contracts.Localization;
using R2Q.Infrastructure.Implementations.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using R2Q.Application.Contracts.Identity;
using R2Q.Domain.Entities;
using R2Q.Domain.Enums;
using R2Q.Infrastructure.Implementations.Identity;
using System.Security.Cryptography;
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
using R2Q.Application.Contracts.DaprService;
using R2Q.Infrastructure.Implementations.DaprServices;

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

            services.AddScoped<ICacheService, DistributedCacheService>();
            services.AddScoped<IRequestContext, RequestContext>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailTemplateReader, HtmlTemplateReader>();
            services.AddSingleton<IEncryptionService, AesEncryptionService>();
            services.AddScoped<IThumbnailGeneratorService, ThumbnailGeneratorService>();

            services.AddScoped<IPubSubNotificationService, NotificationService>();
            services.AddScoped<IDaprService, DaprService>();
            AddLocalizationService(services);
            AddIdentityService(services, configuration);
            return services;
        }
        /// <summary>
        /// Adds the localization service.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddLocalizationService(IServiceCollection services)
        {
            var resourcesPath = Path.Combine(nameof(Implementations), nameof(Implementations.Localization));
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
            //var identityServerParameters = new IdentityServerParameters();
            //configuration.GetSection(InfrastructureConstants.IdentityServerSection)
            //.Bind(identityServerParameters);

            //// Get the private key and create a security key to be used as the signing credential
            //var privateKey = Convert.FromBase64String(identityServerParameters.SigningKey);
            //var ecdsa = ECDsa.Create();
            //ecdsa.ImportECPrivateKey(privateKey, out _);

            //var signingKey = new ECDsaSecurityKey(ecdsa)
            //{
            //    KeyId = identityServerParameters.KeyId
            //};
            //// Added EstimatePageReadOnlyUserPolicy for access view permission for read only users
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(ApplicationConstants.EstimatePageReadOnlyUserPolicy, policy =>
            //           policy.RequireRole(nameof(RoleType.RootAdministrator), nameof(RoleType.Administrator),
            //           nameof(RoleType.Estimator), nameof(RoleType.EstimationManager), nameof(RoleType.BranchManager),
            //           nameof(RoleType.ExecutiveManager), nameof(RoleType.ReadOnlyUser)));
            //}).AddIdentityServer()
            //    .AddInMemoryClients(identityServerParameters.Clients)
            //    .AddInMemoryApiResources(identityServerParameters.ApiResources)
            //    .AddInMemoryApiScopes(identityServerParameters.ApiScopes)
            //    .AddOperationalStore<ApplicationDbContext>(options =>
            //    {
            //        // this enables automatic token cleanup. this is optional.
            //        options.EnableTokenCleanup = true;
            //        options.TokenCleanupInterval = identityServerParameters.TokenCleanupIntervalInSeconds;
            //    })
            //    .AddResourceOwnerValidator<CustomResourceOwnerValidator<ApplicationUser>>()
            //    .AddProfileService<IdentityProfileService>()
            //    .AddSigningCredential(signingKey, ECDsaSigningAlgorithm.ES256);

            //var authenticationOptions = identityServerParameters.AuthenticationOptions;

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(JwtBearerDefaults.AuthenticationScheme, options =>
            //    {
            //        options.ApiName = authenticationOptions.ApiName;
            //        options.Authority = authenticationOptions.Authority;
            //        options.RoleClaimType = authenticationOptions.RoleClaimType;
            //        options.RequireHttpsMetadata = authenticationOptions.RequireHttpsMetadata;
            //        options.JwtValidationClockSkew = authenticationOptions.JwtValidationClockSkew;
            //    });

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddSignalR();
        }

    }
}
