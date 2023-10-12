using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace R2Q.Application.Extensions
{
    /// <summary>
    /// Defines extensions for Json operations
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The camel case serializer settings
        /// </summary>
        private static readonly JsonSerializerSettings camelCaseSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        /// <summary>
        /// Serializes as camel case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string SerializeAsCamelCase(this object value)
        {
            return JsonConvert.SerializeObject(value, camelCaseSerializerSettings);
        }
    }
}
