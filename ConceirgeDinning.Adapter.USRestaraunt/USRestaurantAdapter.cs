
using ConceirgeDinning.Adapter.USRestaraunt.Models;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Restaurant = ConceirgeDinning.Core.Models.Restaurant;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestarauntAdapter : IFetchRestaurant
    {
        public List<Restaurant> FetchRestarauntDetails(string latitude,string longitude,string category)
        {
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance=2";
            var request = System.Net.WebRequest.Create(ApiUri + "&lat=" + latitude + "&lon=" + longitude);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "01545b0594mshdb9591ceda3d162p1716b7jsn43e523b10b95");
            Log.Information("request to supplier: " + ApiUri + "&lat=" + latitude + "&lon=" + longitude);
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
