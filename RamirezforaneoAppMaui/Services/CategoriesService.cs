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

                return await response.Content.ReadFromJsonAsync<List<Category>>() ?? new List<Category>();
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }


        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/CategoriesManagement", category);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/CategoriesManagement/{category.CategoryId}", category);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/CategoriesManagement/{categoryId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Category?> GetCategoryDetailsAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/CategoriesManagement/{categoryId}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Category>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
