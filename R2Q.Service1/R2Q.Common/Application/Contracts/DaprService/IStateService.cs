using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Common.Application.Contracts.DaprService
{
    public interface IStateService
    {
        Task<T> GetStateAsync<T>(string key);
        Task SaveStateAsync(string key, object value);
        Task DeleteStateAsync(string key);
    }
}
