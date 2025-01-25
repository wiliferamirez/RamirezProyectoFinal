using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RamirezforaneoAppMaui.Services;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.ViewModel.Authentication
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;

        [ObservableProperty]
        private string cedulaUser;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string stateName;

        [ObservableProperty]
        private string studyProgram;

        [ObservableProperty]
        private int sessionNumber;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isRegistering;

        public RegisterViewModel(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (IsRegistering) return;

            IsRegistering = true;

            var registerModel = new RegisterRequest
            {
                Email = Email,
                Password = Password,
                CedulaUser = CedulaUser,
                StateName = StateName,
                StudyProgram = StudyProgram,
                SessionNumber = SessionNumber
            };

            var success = await _authenticationService.RegisterAsync(registerModel);

            IsRegistering = false;

            if (success)
            {
                // Handle successful registration (e.g., navigate to login)
                await App.Current.MainPage.DisplayAlert("Success", "Registration complete!", "OK");
            }
            else
            {
                // Handle registration failure
                await App.Current.MainPage.DisplayAlert("Error", "Registration failed. Try again.", "OK");
            }
        }
    }
}
