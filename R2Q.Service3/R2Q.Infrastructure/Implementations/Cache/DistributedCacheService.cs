using System;
using System.Threading.Tasks;
using R2Q.Application.Contracts.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using R2Q.Infrastructure.Constants;

namespace R2Q.Infrastructure.Implementations.Cache
{
    public class DistributedCacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;
        private readonly string environment;
        private readonly CacheServiceParameters cacheServiceParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheService" /> class.
        /// </summary>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="configuration">The configuration.</param>
        public DistributedCacheService(IDistributedCache distributedCache, IConfiguration configuration)
        {
            this.distributedCache = distributedCache;
            this.environment = Environment.GetEnvironmentVariable(InfraConstants.EnvironmentNameKey);
            this.cacheServiceParameters = new CacheServiceParameters();
            configuration.GetSection(nameof(CacheServiceParameters))
                .Bind(cacheServiceParameters);
        }

        /// <summary>
        /// Adds the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="isSlidingExpiration">isSlidingExpiration</param>
        /// <param name="expiryInSeconds">The expiry.</param>
        public async Task AddValueAsync<T>(string key, T value, bool isSlidingExpiration = false, int? expiryInSeconds = null)
        {
            // Use the default expiry if none is provided
            expiryInSeconds ??= cacheServiceParameters.DefaultExpiryInSeconds;
            var environmentKey = GetEnvironmentSpecificKey(key);
            var expiry = new DateTimeOffset(DateTime.UtcNow.AddSeconds(expiryInSeconds.Value));
            var serializedValue = JsonConvert.SerializeObject(value);

            var cacheEntryOptions = new DistributedCacheEntryOptions();
            if (isSlidingExpiration)
            {
                cacheEntryOptions.SlidingExpiration = new TimeSpan(0, 0, 0, expiryInSeconds.Value);
            }
            else
            {
                cacheEntryOptions.AbsoluteExpiration = expiry;
            }

            await distributedCache.SetStringAsync(
                    environmentKey,
                    serializedValue,
                    cacheEntryOptions);
        }

        /// <summary>
        /// Adds a project specific value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public async Task AddProjectValueAsync<T>(string key, T value)
        {
            // Save the value with project item specific expiry
            await AddValueAsync(key, value, true, cacheServiceParameters.ProjectItemExpiryInSeconds);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<T> GetValueAsync<T>(string key)
        {
            var environmentKey = GetEnvironmentSpecificKey(key);
            var serializedValue = await distributedCache.GetStringAsync(environmentKey);
            if (!string.IsNullOrEmpty(serializedValue))
            {
                return JsonConvert.DeserializeObject<T>(serializedValue);
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="getFromPersistentStore">getFromPersistentStore</param>
        /// <param name="expiryInSeconds">The expire time in seconds</param>
        /// <returns></returns>
        public async Task<T> GetValueAsync<T>(
            string key,
            Func<Task<T>> getFromPersistentStore,
            bool isSlidingExpiration = false,
            int? expiryInSeconds = null)
        {
            var result = await GetValueAsync<T>(key);
            if (result != null)
            {
                return result;
            }
            else
            {
                var dataFromDb = await getFromPersistentStore();
                await AddValueAsync(key, dataFromDb, isSlidingExpiration, expiryInSeconds);
                return dataFromDb;
            }
        }

        /// <summary>
        /// Gets a project specific value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="getFromPersistentStore">The get from persistent store.</param>
        /// <returns></returns>
        public async Task<T> GetProjectValueAsync<T>(string key, Func<Task<T>> getFromPersistentStore)
        {
            var result = await GetValueAsync<T>(key);
            if (result != null)
            {
                return result;
            }
            else
            {
                var dataFromDb = await getFromPersistentStore();
                await AddProjectValueAsync(key, dataFromDb);
                return dataFromDb;
            }
        }

        /// <summary>
        /// Removes the value.
        /// </summary>
        /// <param name="key">The key.</param>
        public async Task RemoveValueAsync(string key)
        {
            var environmentKey = GetEnvironmentSpecificKey(key);
            await distributedCache.RemoveAsync(environmentKey);
        }

        #region Private Methods

        /// <summary>
        /// Gets the environment specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetEnvironmentSpecificKey(string key)
        {
            return $"{environment}:{key}";
        }

        #endregion
    }
}
