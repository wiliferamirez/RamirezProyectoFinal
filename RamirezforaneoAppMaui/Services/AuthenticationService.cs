using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using RamirezforaneoAppMaui.Models.Authentication;

namespace RamirezforaneoAppMaui.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> LoginAsync(Login loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Usermanagment/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception("Invalid login credentials."); 
        }

    }
}
