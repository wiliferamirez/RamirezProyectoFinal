using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using RamirezforaneoAppMaui.Models.Admin;

namespace RamirezforaneoAppMaui.Services
{
    public class MarketsService
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
            try
            {
                var response = await _httpClient.GetAsync("api/MarketsManagement");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Market>>(jsonResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching markets: {ex.Message}");
                return new List<Market>(); 
            }
        }

        public async Task<bool> AddMarketAsync(Market newMarket)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(newMarket), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/MarketsManagement", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error adding market: {response.ReasonPhrase}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding market: {ex.Message}");
                return false;
            }
        }
    }
}
