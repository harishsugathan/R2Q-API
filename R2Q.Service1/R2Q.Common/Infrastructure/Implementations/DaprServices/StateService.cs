

using Microsoft.Extensions.Configuration;
using R2Q.Common.Application.Constants;
using R2Q.Common.Application.Contracts.DaprService;

namespace R2Q.Common.Infrastructure.Implementations.DaprServices
{
    public class StateService : IStateService
    {
        private readonly DaprClient daprClient;

        public StateService(DaprClient daprClient, IConfiguration configuration)
        {
            this.daprClient = daprClient;
        }
        public async Task<T> GetStateAsync<T>(string key)
        {
            return await daprClient.GetStateAsync<T>(Constants.stateStoreName, key);
        }
        public async Task SaveStateAsync(string key, object value)
        {
            await daprClient.SaveStateAsync(Constants.stateStoreName, key, value);
        }
        public async Task DeleteStateAsync(string key)
        {
            await daprClient.DeleteStateAsync(Constants.stateStoreName, key);
        }
    }
}
