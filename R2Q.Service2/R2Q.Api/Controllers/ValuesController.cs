using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace R2Q.Service1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;

        public ValuesController(IHttpClientFactory factory)
        {
            this._factory = factory;
        }

        // GET api/values  
        [HttpGet("Values/getvendor")]
        public async Task<IEnumerable<string>> GetVendor()
        {
            var data = await GetSomeThingFromOrderApi();

            return new string[] { "value1", "value2" };
        }
        private async Task<string> GetSomeThingFromOrderApi()
        {
            var client = _factory.CreateClient("orderApi");

            var requestMsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5117/api/orders");

            var responseMsg = await client.SendAsync(requestMsg);

            var data = await responseMsg.Content.ReadAsStringAsync();

            return data;
        }
    }
}
