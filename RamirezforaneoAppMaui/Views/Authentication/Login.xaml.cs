namespace RamirezforaneoAppMaui.Views.Authentication;
using RamirezforaneoAppMaui.ViewModel.Authentication;
using RamirezforaneoAppMaui.Services;
using CommunityToolkit.Mvvm.Input;



public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
    }
    public Login(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
        
    }



    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {

    }

}