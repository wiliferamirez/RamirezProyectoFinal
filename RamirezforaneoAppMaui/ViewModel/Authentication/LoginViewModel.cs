using RamirezforaneoAppMaui.Models.Authentication;
using RamirezforaneoAppMaui.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net.Http.Json;

namespace RamirezforaneoAppMaui.ViewModel.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public LoginViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7242/")
            };
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter email and password", "OK");
                return;
            }

            try
            {
                var loginModel = new { Email, Password };
                var response = await _httpClient.PostAsJsonAsync("api/UserManagement/login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    await Shell.Current.GoToAsync("///MainPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Login Failed", "Invalid credentials", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Connection error: {ex.Message}", "OK");
            }
        }
    }
}
