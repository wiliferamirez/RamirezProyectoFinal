using RamirezforaneoAppMaui.Models.Admin;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace RamirezforaneoAppMaui.Services
{
    public class MarketsService
    {
        private readonly HttpClient _httpClient;

        public MarketsService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<List<Market>> GetMarketsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement");
            var marketItems = JsonSerializer.Deserialize<List<Market>>(response);


            foreach (var market in marketItems)
            {
                market.ItemSeller = market.ItemSeller ?? "No Seller Info";  
                market.Category = market.Category ?? "Uncategorized";  
            }

            return marketItems;
        }

        public async Task<bool> AddMarketAsync(Market market)
        {
            var content = new StringContent(JsonSerializer.Serialize(market), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMarketAsync(int marketItemId)
        {
            var response = await _httpClient.DeleteAsync($"https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement/{marketItemId}");
            return response.IsSuccessStatusCode;
        }
    }
}
