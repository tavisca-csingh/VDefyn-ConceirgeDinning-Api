using ConceirgeDinning.Adapter.USRestaraunt.Models;
using ConceirgeDinningContracts.Services;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using RestaurantDetails = ConceirgeDinning.Contracts.Models.RestaurantDetails;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestaurantDetailsAdapter : IFetchRestaurantDetails
    {
        private readonly string _usrestaurantURL;
        private readonly string _usrestaurantKey;
        public USRestaurantDetailsAdapter(string url, string key)
        {
            this._usrestaurantKey = url;
            this._usrestaurantURL = key;
        }
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            
            var request = System.Net.WebRequest.Create(_usrestaurantURL + restaurantId + "/menuitems");
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", _usrestaurantKey);
            Log.Information("request to supplier: "+ _usrestaurantURL + restaurantId + "/menuitems");
            request.ContentType = "application/json";


            using (HttpWebResponse response =(HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Log.Information("response from supplier: " + HttpStatusCode.NotFound);
                    return null;
                }
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();

                    RestaurantDetailResponse restaurantDetails = JsonConvert.DeserializeObject<RestaurantDetailResponse>(result);
                    Log.Information("response from supplier: " + JsonConvert.SerializeObject(response));

                    return restaurantDetails.TranslateToRestaurantDetails();
                }
            }

        }
    }
}
