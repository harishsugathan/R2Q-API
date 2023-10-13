using Azure.Core;
using Newtonsoft.Json;
using R2Q.Application.Contracts.Services;
using R2Q.Application.Contracts.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Infrastructure.Implementations.Services
{
    public class TripService : ITripService
    {

        private readonly HttpClient httpClient;

        public TripService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task UpdateAsync(TripData trip, string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/health/ping")
            {
                Content = JsonContent.Create(trip)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        public async Task<string> GetAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/health/ping");
            var response = await httpClient.SendAsync(request);
            if (response != null)
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                return responseStr;
            }
            return default;
        }
    }
}
