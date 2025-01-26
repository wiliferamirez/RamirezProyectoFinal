namespace RamirezforaneoAppMaui.Views.Authentication;
using RamirezforaneoAppMaui.ViewModel.Authentication;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    public Register(RegisterViewModel registerViewModel)
    {
        InitializeComponent();
        BindingContext = registerViewModel;
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {

    }
}