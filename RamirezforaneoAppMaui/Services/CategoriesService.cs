using System.Net.Http.Json;
using RamirezforaneoAppMaui.Models.Admin;


namespace RamirezforaneoAppMaui.Services
{
    public class CategoriesService
    {
        private readonly HttpClient _httpClient;

        public CategoriesService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rh4p8xrf-5262.use2.devtunnels.ms/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/CategoriesManagement");
                response.EnsureSuccessStatusCode(); 

                return await response.Content.ReadFromJsonAsync<List<Category>>();
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

    }
}
