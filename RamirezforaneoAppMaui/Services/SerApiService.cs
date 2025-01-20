using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using SerpApi;

namespace RamirezforaneoAppMaui.Services
{
    public class SerApiService
    {
        private readonly string _apiKey;

        public SerApiService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<LocalResult> SearchPlaces(string query, string location)
        {
            var results = new List<LocalResult>();

            // Use Hashtable instead of Dictionary
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
                        results.Add(new LocalResult
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

        public class LocalResult
        {
            public string PlaceName { get; set; }
            public string PlaceAddress { get; set; }
            public string PlacePhone { get; set; }
            public string PlaceImageUrl { get; set; }
        }
    }
}
