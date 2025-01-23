using RamirezforaneoAppMaui.ViewModel;
using RamirezforaneoAppMaui.Models;

namespace RamirezforaneoAppMaui.Views.GoogleResults;

public partial class Index : ContentPage
{
	private readonly PlaceResultViewModel _placeResultViewModel;
	public Index()
	{
		InitializeComponent();
		_placeResultViewModel = new PlaceResultViewModel();
		BindingContext = _placeResultViewModel;
	}

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
		string query = SearchQuery.Text;
		if (!string.IsNullOrEmpty(query))
		{
			string location = "@-0.16235095277405412,-78.45915383165817,15.1z"; //Udla Park Location
			await _placeResultViewModel.SearchPlaces(query, location);
        }
		else
		{
            await DisplayAlert("Input Error", "Please enter a search query.", "OK");
        }


    }
}