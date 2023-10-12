using R2Q.Application.Contracts.Services;
using R2Q.Application.Contracts.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Infrastructure.Implementations.Services
{
    public class TripService : ITripService
    {

        private readonly HttpClient _httpClient;

        public TripService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateAsync(TripData trip, string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/trip")
            {
                Content = JsonContent.Create(trip)
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
