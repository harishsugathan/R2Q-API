
using Dapr.Client;
using Microsoft.Extensions.Configuration;

namespace R2Q.Infrastructure.Services
{
    public class DaprService
    {
        private readonly DaprClient _daprClient;

        public DaprService(DaprClient daprClient, IConfiguration configuration)
        {
            _daprClient = daprClient;
        }
        public async Task<object> InvokeOtherServiceAsync(string appId, string methodName)
        {
            var response = await _daprClient.InvokeMethodAsync<string>(appId, methodName);
            return response;
        }
        public async Task<T> GetStateAsync<T>(string storeName, string key)
        {
            return await _daprClient.GetStateAsync<T>(storeName, key);
        }
        public async Task SaveStateAsync(string storeName, string key, object value)
        {
            await _daprClient.SaveStateAsync(storeName, key, value);
        }
        public async Task PublishAsync(string pubSubName, string topic, object data)
        {
            await _daprClient.PublishEventAsync(pubSubName, topic, data);
        }
    }
}
