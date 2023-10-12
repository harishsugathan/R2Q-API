using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Common.Application.Contracts.DaprService
{
    public interface IInvokeService
    {
        Task<T> InvokeOtherServiceAsync<T>(HttpMethod httpMethod,string appId, string methodName);
    }
}
