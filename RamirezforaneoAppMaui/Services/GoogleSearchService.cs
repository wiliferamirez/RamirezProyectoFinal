using Newtonsoft.Json.Linq;
using SerpApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RamirezforaneoAppMaui.Models;
using System.Collections;

namespace RamirezforaneoAppMaui.Services
{
    public class GoogleSearchService
    {
        private readonly string _apiKey;

        public GoogleSearchService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<PlaceResult> SearchNearbyPlaces(string query, string location)
        {
            var results = new List<PlaceResult>();

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
                        results.Add(new PlaceResult
                        {
                            PlaceName = result["title"]?.ToString(),
                            PlaceAddress = result["address"]?.ToString(),
                            PlacePhone = result["phone"]?.ToString(),
                            PlaceImageUrl = result["thumbnail"]?.ToString()
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
