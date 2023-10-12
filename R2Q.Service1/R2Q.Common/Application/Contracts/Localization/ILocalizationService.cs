

using Microsoft.Extensions.Localization;

namespace R2Q.Common.Application.Contracts.Localization
{
    /// <summary>
    /// Interface that defines the necessary methods for a Localization Service implementation
    /// </summary>
    public interface ILocalizationService
    {
        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        LocalizedString GetLocalizedString(string key);

        /// <summary>
        /// Gets the localized string by culture code.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cultureCode">The culture code.</param>
        /// <returns></returns>
        LocalizedString GetLocalizedStringByCultureCode(string key, string cultureCode);
    }
}
