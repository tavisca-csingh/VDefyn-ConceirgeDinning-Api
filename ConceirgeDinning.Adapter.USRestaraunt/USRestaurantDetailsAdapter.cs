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

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestaurantDetailsAdapter : IFetchRestaurantDetails
    {
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurant/";
            var request = System.Net.WebRequest.Create(ApiUri + restaurantId + "/menuitems");
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "01545b0594mshdb9591ceda3d162p1716b7jsn43e523b10b95");
            Log.Information("request to supplier: "+ ApiUri + restaurantId + "/menuitems");
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
