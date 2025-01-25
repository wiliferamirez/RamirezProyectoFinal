using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RamirezforaneoAppMaui.Services;
using System.Net.Http.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using RamirezforaneoAppMaui.Models.Authentication;

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
            if (string.IsNullOrWhiteSpace(CedulaUser) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(StateName) || string.IsNullOrWhiteSpace(StudyProgram) || SessionNumber <= 0 || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill all fields", "OK");
                return;
            }
            IsRegistering = true;
            var registerModel = new Register
            {
                CedulaUser = CedulaUser,
                Email = Email,
                StateName = StateName,
                StudyProgram = StudyProgram,
                SessionNumber = SessionNumber,
                Password = Password
            };
            var success = await _authenticationService.RegisterAsync(registerModel);
            if (success)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Registration successful!", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Registration failed. Please try again.", "OK");
            }
            IsRegistering = false;
        }
    }
}
