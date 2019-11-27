
using ConceirgeDinning.Adapter.USRestaraunt.Models;
using ConceirgeDinningContracts.Services;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Restaurant = ConceirgeDinning.Contracts.Models.Restaurant;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestarauntAdapter : IFetchRestaurant
    {
        private readonly string _usrestaurantURL;
        private readonly string _usrestaurantKey;
        public USRestarauntAdapter(string url,string key)
        {
            this._usrestaurantURL = url;
            this._usrestaurantKey = key;
        }
        public List<Restaurant> FetchRestarauntDetails(string latitude,string longitude,string category)
        {
            var request = System.Net.WebRequest.Create(_usrestaurantURL + "&lat=" + latitude + "&lon=" + longitude);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", _usrestaurantKey);
            Log.Information("request to supplier: " + _usrestaurantURL + "&lat=" + latitude + "&lon=" + longitude);
            request.ContentType = "application/json";

            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                        var result = reader.ReadToEnd();

                        SearchResponse restaurantDetails = JsonConvert.DeserializeObject<SearchResponse>(result);

                        Log.Information("response from supplier: " + JsonConvert.SerializeObject(result));

                        return restaurantDetails.TranslateToRestaurant();
                       
                    }
                }
            }
            catch(System.Net.WebException ex)
            {
                Log.Information("response from supplier: " + ex);
                return null;
            }


        }
    }
}
