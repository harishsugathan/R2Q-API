
using Dapr.Client;
using Microsoft.Extensions.Configuration;
using R2Q.Application.Contracts.DaprService;

namespace R2Q.Infrastructure.Implementations.DaprServices
{
    public class DaprService: IDaprService
    {
        private readonly DaprClient daprClient;

        public DaprService(DaprClient daprClient, IConfiguration configuration)
        {
            this.daprClient = daprClient;
        }
        public async Task<T> InvokeOtherServiceAsync<T>(HttpMethod httpMethod,string appId, string methodName)
        {
            HttpRequestMessage daprRequest = daprClient.CreateInvokeMethodRequest(httpMethod, appId, methodName);
            daprRequest.Headers.Add("api-version", "v1");
            var response = await daprClient.InvokeMethodAsync<T>(daprRequest);
           
            return response;
        }
        public async Task<T> GetStateAsync<T>(string storeName, string key)
        {
            return await daprClient.GetStateAsync<T>(storeName, key);
        }
        public async Task SaveStateAsync(string storeName, string key, object value)
        {
            await daprClient.SaveStateAsync(storeName, key, value);
        }
        public async Task PublishAsync(string pubSubName, string topic, object data)
        {
            await daprClient.PublishEventAsync(pubSubName, topic, data);
        }
    }
}
