using DotNetCore8Api.Models;
using DotNetCore8Api.Services.Interfaces;

namespace DotNetCore8Api.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        public FanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Fan>> GetFans()
        {
            throw new NotImplementedException();
        }
    }
}
