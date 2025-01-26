using System.Net.Http.Json;
using RamirezforaneoAppMaui.Models.Admin;

namespace RamirezforaneoAppMaui.Services
{
    public class EventsService
    {
        private readonly HttpClient _httpClient;

        public EventsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rh4p8xrf-5262.use2.devtunnels.ms/");
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/EventsManagement");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Event>>() ?? new List<Event>();
            }
            catch (Exception ex)
            {
     
                return new List<Event>();
            }
        }
        
        public async Task<bool> AddEventAsync(Event newEvent)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/EventsManagement", newEvent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
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
    }
}
