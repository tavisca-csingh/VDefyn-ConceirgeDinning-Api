using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestaurantDetailService : IRestaurantDetailService
    {
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurant/";
            var request = System.Net.WebRequest.Create(ApiUri + restaurantId + "/menuitems");
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

                    Models.RestaurantDetailResponse Response = JsonConvert.DeserializeObject<Models.RestaurantDetailResponse>(result);


                    var searchResults = SupplierModelsToUiModelsTranslator.TranslateToRestaurantDetails(Response);
                    return searchResults;
                }
            }

        }
    }
}
