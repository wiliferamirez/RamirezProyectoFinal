using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RamirezforaneoAppMaui.Models.Admin;
using RamirezforaneoAppMaui.Services;
using System.Collections.ObjectModel;

namespace RamirezforaneoAppMaui.ViewModel.Admin
{
    public partial class MarketsViewModel : ObservableObject
    {
        private readonly MarketsService _marketsService;

        [ObservableProperty]
        private ObservableCollection<Market> markets;

        [ObservableProperty]
        private string newMarketTitle;

        [ObservableProperty]
        private string newMarketDescription;

        [ObservableProperty]
        private int selectedCategoryId;

        [ObservableProperty]
        private string newMarketLocation;

        [ObservableProperty]
        private DateTime marketStartDate;

        [ObservableProperty]
        private DateTime marketEndDate;

        [ObservableProperty]
        private Category selectedCategory;

        public MarketsViewModel()
        {
            _marketsService = new MarketsService();
            Markets = new ObservableCollection<Market>();
            LoadMarketsAsync();
        }

        [RelayCommand]
        private async Task LoadMarketsAsync()
        {
            var marketList = await _marketsService.GetMarketsAsync();
            Markets = new ObservableCollection<Market>(marketList);
        }

        [RelayCommand]
        public async Task CreateMarketAsync()
        {
            if (!string.IsNullOrWhiteSpace(newMarketTitle) &&
                !string.IsNullOrWhiteSpace(newMarketDescription) &&
                !string.IsNullOrWhiteSpace(newMarketLocation) &&
                marketStartDate != default &&
                marketEndDate != default)
            {
                var newMarket = new Market
                {
                    EventTitle = newMarketTitle,
                    EventDescription = newMarketDescription,
                    CategoryId = selectedCategoryId,
                    EventLocation = newMarketLocation,
                    EventStartDate = marketStartDate,
                    EventEndDate = marketEndDate
                };

                var success = await _marketsService.AddMarketAsync(newMarket);
                if (success)
                {
                    // Handle success (e.g., navigate back, show success message)
                }
                else
                {
                    // Handle failure (e.g., show error message)
                }
            }
            else
            {
                // Handle validation errors (e.g., show validation error messages)
            }
        }

    }
}
