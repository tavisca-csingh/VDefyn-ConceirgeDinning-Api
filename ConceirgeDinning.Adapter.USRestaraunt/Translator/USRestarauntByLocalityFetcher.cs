
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestarauntByLocalityFetcher : IRestaurantByLocalityFetcher
    {
        public List<Restaurant> FetchRestarauntDetails(LocalityGeocode locality)
        {
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance=2";
            var request = System.Net.WebRequest.Create(ApiUri + "&lat=" + locality.Latitude + "&lon=" + locality.Longitude);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "0416d26f02msh589cf430c166051p1c0a3djsn6029f7f1a261");

            request.ContentType = "application/json";


            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();

                    Models.SearchResponse Response = JsonConvert.DeserializeObject<Models.SearchResponse>(result);
                    

                    var searchResults = SupplierModelsToUiModelsTranslator.TranslateToRestaurant(Response);
                    return searchResults;
                }
            }


        }
    }
}
