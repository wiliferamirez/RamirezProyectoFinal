using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RamirezforaneoAppMaui.Services;

namespace RamirezforaneoAppMaui.ViewModels
{
    public class SearchViewModel
    {
        private readonly SerApiService _serApiService;

        public ObservableCollection<SerApiService.LocalResult> SearchResults { get; set; }

        public SearchViewModel()
        {
            _serApiService = new SerApiService("5eac90135f2cc2d291e16e6783cf3c81c3eaab83b5f8747b38afac5c60f05a20"); // Replace with your actual API key
            SearchResults = new ObservableCollection<SerApiService.LocalResult>();
        }

        public async Task SearchPlacesAsync(string query, string location)
        {
            var results = await Task.Run(() => _serApiService.SearchPlaces(query, location));

            SearchResults.Clear();

            var limitedResults = results.Take(5).ToList();

            foreach (var result in limitedResults)
            {
                SearchResults.Add(result);
            }
        }
    }
}
