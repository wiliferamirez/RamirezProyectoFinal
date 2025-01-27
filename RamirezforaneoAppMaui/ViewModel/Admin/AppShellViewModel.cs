using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public class AppShellViewModel : BindableObject
    {
        private bool _isLoggedOut = true;

        // Property to check if user is logged out
        public bool IsLoggedOut
        {
            get => _isLoggedOut;
            set
            {
                _isLoggedOut = value;
                OnPropertyChanged();
            }
        }

        public AppShellViewModel()
        {
            // Set the logged-out state here based on your app logic
            IsLoggedOut = !IsUserLoggedIn();
        }

        private bool IsUserLoggedIn()
        {
            // Retrieve the stored token or session information using Preferences
            var userToken = Preferences.Get("user_token", string.Empty);
            return !string.IsNullOrEmpty(userToken);
        }
    }
}
