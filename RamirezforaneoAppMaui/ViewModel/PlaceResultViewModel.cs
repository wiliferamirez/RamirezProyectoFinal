using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RamirezforaneoAppMaui.Services;
using RamirezforaneoAppMaui.Models;
using System.Collections.ObjectModel;

namespace RamirezforaneoAppMaui.ViewModel
{
    public class PlaceResultViewModel
    {
        private readonly GoogleSearchService _searchService;
        public ObservableCollection<PlaceResult> Results { get; private set; }

        public PlaceResultViewModel()
        {
            _searchService = new GoogleSearchService("5eac90135f2cc2d291e16e6783cf3c81c3eaab83b5f8747b38afac5c60f05a20");
            Results = new ObservableCollection<PlaceResult>();
        }

        public async Task SearchPlaces(string query, string location)
        {
            var results = await Task.Run(() => _searchService.SearchNearbyPlaces(query, location));
            Results.Clear();

            var topResults = Results.Take(5).ToList();
            foreach (var result in results)
            {

                Results.Add(result);
            }
        }

    }
}
