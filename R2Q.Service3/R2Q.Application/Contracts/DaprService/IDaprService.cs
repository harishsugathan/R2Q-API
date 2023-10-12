using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.DaprService
{
    public interface IDaprService
    {
        Task<T> InvokeOtherServiceAsync<T>(HttpMethod httpMethod,string appId, string methodName);
        Task<T> GetStateAsync<T>(string storeName, string key);
        Task SaveStateAsync(string storeName, string key, object value);
        Task PublishAsync(string pubSubName, string topic, object data);
    }
}
