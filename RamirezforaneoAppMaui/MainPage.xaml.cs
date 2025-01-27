namespace RamirezforaneoAppMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToMarketsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//IndexMarketsPage");
        }

        private async void OnNavigateToEventsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//IndexEventsPage");
        }

        private async void OnNavigateToCategoriesClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//IndexCategoryPage");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnNavigateToGoogleSearchClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//GoogleResultsPage");
        }
    }

}
