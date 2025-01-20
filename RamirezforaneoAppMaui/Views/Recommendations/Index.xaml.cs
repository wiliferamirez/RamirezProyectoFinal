using RamirezforaneoAppMaui.ViewModels;

namespace RamirezforaneoAppMaui.Views.Recommendations {

    public partial class Index : ContentPage
    {
        private readonly SearchViewModel _viewModel;

        public Index()
        {
            InitializeComponent();
            _viewModel = new SearchViewModel();
            BindingContext = _viewModel;
        }


        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string query = SearchQuery.Text;
            if (!string.IsNullOrEmpty(query))
            {

                string location = "@-0.16235095277405412,-78.45915383165817,15.1z";
                await _viewModel.SearchPlacesAsync(query, location);
            }
            else
            {
                await DisplayAlert("Input Error", "Please enter a search query.", "OK");
            }
        }
    }

}