﻿using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
        }
    }
}
