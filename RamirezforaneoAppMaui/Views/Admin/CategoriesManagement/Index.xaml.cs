using RamirezforaneoAppMaui.ViewModel.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.CategoriesManagement;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
        BindingContext = new CategoriesViewModel();
    }
}