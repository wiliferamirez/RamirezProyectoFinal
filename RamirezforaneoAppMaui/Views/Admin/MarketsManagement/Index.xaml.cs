using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.MarketsManagement;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
        BindingContext = new MarketsViewModel();
    }

}