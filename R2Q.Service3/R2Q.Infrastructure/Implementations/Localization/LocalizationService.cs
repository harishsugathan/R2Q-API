using System.Globalization;
using System.Reflection;
using R2Q.Application.Contracts.Localization;
using Microsoft.Extensions.Localization;
using System.Resources;

namespace R2Q.Infrastructure.Implementations.Localization
{
    /// <summary>
    /// A class with language localization methods
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer localizer;

        /// <summary>
        /// Initializes LocalizationService
        /// </summary>
        /// <param name="factory"></param>
        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(ResourceSet);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(ResourceSet), assemblyName.Name);
        }

        /// <summary>
        /// Returns the localized string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public LocalizedString GetLocalizedString(string key)
        {
            return localizer[key];
        }

        /// <summary>
        /// Returns the localized string for the supplied culture code
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        public LocalizedString GetLocalizedStringByCultureCode(string key, string cultureCode)
        {
            // Capture current culture
            var currentCulture = CultureInfo.CurrentCulture;

            // Change current culture to the input culture
            CultureInfo.CurrentCulture = new CultureInfo(cultureCode);
            CultureInfo.CurrentUICulture = new CultureInfo(cultureCode);

            var value = localizer[key];

            // Set current culture
            CultureInfo.CurrentCulture = new CultureInfo(currentCulture.Name);
            CultureInfo.CurrentUICulture = new CultureInfo(currentCulture.Name);
            return value;
        }
    }
}
