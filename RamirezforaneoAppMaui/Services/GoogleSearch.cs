
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.Services
{
    public class GoogleSearch
    {
        private readonly string _apiKey;

        public GoogleSearch(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<SearchResult> WRSearchNearbyPlaces(string query, string location)
        {
            var results = new List<SearchResult>();

            Hashtable ht = new Hashtable
            {
                { "engine", "google_maps" },
                { "q", query },
                { "ll", location },
                { "type", "search" }
            };

            try
            {
                GoogleSearch search = new GoogleSearch(ht, _apiKey);
                JObject data = search.GetJson();
                var localResults = data["local_results"];

                if (localResults != null)
                {
                    foreach (var result in localResults)
                    {
                        results.Add(new SearchResult
                        {
                            WRPlaceName = result["title"]?.ToString(),
                            WRPlaceAddress = result["address"]?.ToString(),
                            WRPlacePhone = result["phone"]?.ToString(),
                            WRPlaceImageUrl = result["thumbnail"]?.ToString()
                        });
                    }
                }
            }
            catch (SerpApiSearchException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return results;
        }
    }
}
