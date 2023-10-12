using System;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.Cache
{
    /// <summary>
    /// Defines the interface for the cache service
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Adds the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="isSlidingExpiration">isSlidingExpiration</param>
        /// <param name="expiryInSeconds">The expiry in seconds.</param>
        /// <returns></returns>
        Task AddValueAsync<T>(string key, T value, bool isSlidingExpiration = false, int? expiryInSeconds = null);

        /// <summary>
        /// Adds a project specific value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        Task AddProjectValueAsync<T>(string key, T value);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<T> GetValueAsync<T>(string key);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="getFromPersistentStore">getFromPersistentStore</param>
        /// <param name="isSlidingExpiration">isSlidingExpiration</param>
        /// <param name="expiryInSeconds">The expire time in seconds</param>
        /// <returns></returns>
        Task<T> GetValueAsync<T>(
            string key,
            Func<Task<T>> getFromPersistentStore,
            bool isSlidingExpiration = false,
            int? expiryInSeconds = null);

        /// <summary>
        /// Gets a project specific value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="getFromPersistentStore">The get from persistent store.</param>
        /// <returns></returns>
        Task<T> GetProjectValueAsync<T>(string key, Func<Task<T>> getFromPersistentStore);

        /// <summary>
        /// Removes the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task RemoveValueAsync(string key);
    }
}
