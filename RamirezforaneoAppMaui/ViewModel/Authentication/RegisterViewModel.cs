﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RamirezforaneoAppMaui.Services;
using RamirezforaneoAppMaui.Models.Authentication;

namespace RamirezforaneoAppMaui.ViewModel.Authentication
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;
        private readonly HttpClient _httpClient;

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
        public RegisterViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://rh4p8xrf-5262.use2.devtunnels.ms/")
            };
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
                await Shell.Current.GoToAsync("///MainPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Registration failed. Please try again.", "OK");
            }
            IsRegistering = false;
        }
    }
}
