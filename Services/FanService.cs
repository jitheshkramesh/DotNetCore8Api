using DotNetCore8Api.Configuration;
using DotNetCore8Api.Models;
using DotNetCore8Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace DotNetCore8Api.Services
{
    public class FanService : IFanService
    {
        private readonly ApiServiceConfig _config;
        private readonly HttpClient _httpClient;
        public FanService(HttpClient httpClient,
            IOptions<ApiServiceConfig> config)
        {
            _httpClient = httpClient;
            _config = config.Value;
        }
        public async Task<List<Fan>?> GetFans()
        {
            var response = await _httpClient.GetAsync(_config.Url);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new List<Fan>();
                case HttpStatusCode.Unauthorized:
                    return null;
                default:
                    {
                        var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();
                        return fans;
                    }
            }



        }
    }
}
