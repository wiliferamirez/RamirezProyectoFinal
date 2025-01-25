using RamirezforaneoAppMaui.Models.Authentication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RamirezforaneoAppMaui.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7242/");
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var loginModel = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/UserManagement/login", loginModel);
            return await response.Content.ReadFromJsonAsync<LoginResponse>();

        }
        public async Task<bool> RegisterAsync(RegisterRequest registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserManagement/register", registerModel);
            return response.IsSuccessStatusCode;
        }
    }

    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CedulaUser { get; set; }
        public string StateName { get; set; }
        public string StudyProgram { get; set; }
        public int SessionNumber { get; set; }
    }

    public class LoginResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
