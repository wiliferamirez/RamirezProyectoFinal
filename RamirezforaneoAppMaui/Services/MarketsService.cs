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

        // Get all market items
        public async Task<List<Market>> GetMarketsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement");
            var marketItems = JsonSerializer.Deserialize<List<Market>>(response);

            // Handle missing ItemSeller and Category values
            foreach (var market in marketItems)
            {
                // Set default values if null
                market.ItemSeller = market.ItemSeller ?? "No Seller Info";  // Default if null
                market.Category = market.Category ?? "Uncategorized";      // Default if null
            }

            return marketItems;
        }

        // Create a new market item
        public async Task<bool> AddMarketAsync(Market market)
        {
            var content = new StringContent(JsonSerializer.Serialize(market), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement", content);
            return response.IsSuccessStatusCode;
        }

        // Optionally, delete a market item
        public async Task<bool> DeleteMarketAsync(int marketItemId)
        {
            var response = await _httpClient.DeleteAsync($"https://rh4p8xrf-5262.use2.devtunnels.ms/api/MarketsManagement/{marketItemId}");
            return response.IsSuccessStatusCode;
        }
    }
}
