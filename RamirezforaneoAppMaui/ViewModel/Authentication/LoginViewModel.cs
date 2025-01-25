using RamirezforaneoAppMaui.Models.Authentication;
using RamirezforaneoAppMaui.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace RamirezforaneoAppMaui.ViewModel.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;

        // Constructor
        public LoginViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public LoginViewModel() : this(new AuthenticationService(new HttpClient()))
        {
        }

        // Observable properties for binding
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        // Async command to handle login
        public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(LoginAsync);

        // Async login logic
        public async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in both email and password", "OK");
                return;
            }

            var loginModel = new Login
            {
                Username = _email,
                Password = _password
            };

            try
            {
                var response = await _authenticationService.LoginAsync(loginModel);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync(nameof(MainPage));  // Navigate to main page
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid login attempt", "OK");
                }
            }
            catch
            {
                // If there’s an error connecting, display a basic message
                await Application.Current.MainPage.DisplayAlert("Error", "Error connecting to the server", "OK");
            }
        }
    }
}
