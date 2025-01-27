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
        private string newMarketName;

        [ObservableProperty]
        private string newMarketDescription;

        [ObservableProperty]
        private decimal newMarketPrice;

        public MarketsViewModel()
        {
            _marketsService = new MarketsService();
            Markets = new ObservableCollection<Market>();
            LoadMarketsAsync();
        }

        [RelayCommand]
        private async Task LoadMarketsAsync()
        {
            var marketItems = await _marketsService.GetMarketsAsync();
            Markets.Clear();

 
            foreach (var market in marketItems)
            {
                var marketToAdd = new Market
                {
                    MarketItemId = market.MarketItemId,
                    CategoryId = market.CategoryId,
                    ItemCreationDate = market.ItemCreationDate,
                    ItemDescription = market.ItemDescription,
                    ItemImageUrl = market.ItemImageUrl,
                    ItemName = market.ItemName,
                    ItemPrice = market.ItemPrice,
                    ItemSeller = market.ItemSeller,  
                    Category = market.Category  
                };

                Markets.Add(marketToAdd);
            }
        }

        [RelayCommand]
        private async Task AddMarketAsync()
        {
            var newMarket = new Market
            {
                ItemName = newMarketName,
                ItemDescription = newMarketDescription,
                ItemPrice = newMarketPrice
            };

            bool success = await _marketsService.AddMarketAsync(newMarket);

            if (success)
            {
                await LoadMarketsAsync();  
            }
            else
            {

            }
        }
    }
}
