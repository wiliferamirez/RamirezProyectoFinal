using RamirezforaneoAppMaui.ViewModel.Admin;
using RamirezforaneoAppMaui.Models.Admin;
namespace RamirezforaneoAppMaui.Views.Admin.CategoriesManagement;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
        BindingContext = new CategoriesViewModel();
    }

    private async void OnCategoryTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Category selectedCategory)
        {
            var viewModel = BindingContext as CategoriesViewModel;

            if (viewModel != null)
            {
                viewModel.SelectedCategory = selectedCategory; 
            }

            await Shell.Current.GoToAsync("///ActionsCategoriesPage");
        }

            ((ListView)sender).SelectedItem = null;
    }
}