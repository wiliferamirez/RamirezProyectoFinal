using System.Text;
using RamirezforaneoAppMaui.Models.Admin;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.Services
{
    public class MaketsService
    {
        private readonly HttpClient _httpClient;

        public MarketsService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://rh4p8xrf-5262.use2.devtunnels.ms/") // Adjust the base URL
            };
        }

        public async Task<List<Market>> GetMarketsAsync()
        {
            var response = await _httpClient.GetAsync("api/MarketsManagement");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Market>>(data);
            }
            return new List<Market>();
        }

        public async Task<bool> AddMarketAsync(Market newMarket)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(newMarket), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/MarketsManagement", jsonContent);
            return response.IsSuccessStatusCode;
        }
    }
}
