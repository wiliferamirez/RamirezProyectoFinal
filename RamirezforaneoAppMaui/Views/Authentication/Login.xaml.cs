namespace RamirezforaneoAppMaui.Views.Authentication;
using RamirezforaneoAppMaui.ViewModel.Authentication;



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



    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RegisterPage");
    }

}