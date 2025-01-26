using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.EventsManagement;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
        BindingContext = new EventsViewModel();
    }
}