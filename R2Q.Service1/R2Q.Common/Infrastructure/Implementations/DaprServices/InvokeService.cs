
using Dapr.Client;
using Grpc.Net.Client.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using R2Q.Common.Application.Contracts.DaprService;

namespace R2Q.Common.Infrastructure.Implementations.DaprServices
{
    public class InvokeService : IInvokeService
    {
        private readonly DaprClient daprClient;

        public InvokeService(DaprClient daprClient, IConfiguration configuration)
        {
            this.daprClient = daprClient;
        }
        public async Task<T> InvokeOtherServiceAsync<T>(HttpMethod httpMethod, string appId, string methodName)
        {
            var daprRequest = daprClient.CreateInvokeMethodRequest(httpMethod, appId, methodName);

            //var response = await daprClient.InvokeMethodAsync<T>(daprRequest);

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(daprRequest);

                if (response!=null)
                {
                    var responseStr = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(responseStr);
                }                
            }

            return default;            
        }
    }
}
