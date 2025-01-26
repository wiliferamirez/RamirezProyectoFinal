using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.EventsManagement;

public partial class CreateEvent : ContentPage
{
	public CreateEvent()
	{
		InitializeComponent();
        BindingContext = new EventsViewModel();
    }
}