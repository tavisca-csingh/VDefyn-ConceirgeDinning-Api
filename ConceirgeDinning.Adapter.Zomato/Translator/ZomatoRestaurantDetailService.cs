using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class ZomatoRestaurantDetailService : IRestaurantDetailService
    {
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            string ApiUri = @"https://developers.zomato.com/api/v2.1/restaurant?res_id=";
            var request = System.Net.WebRequest.Create(ApiUri + restaurantId);
            request.Method = "GET";
            request.Headers.Add("user-key", "3d95592a1bf9c01986d17292db075163");

            request.ContentType = "application/json";


            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();

                    Models.RestaurantDetails Response = JsonConvert.DeserializeObject<Models.RestaurantDetails>(result);



                    var searchResults = SupplierModelsToUiModelsTranslator.TranslateToRestaurantDetails(Response);








                    return searchResults;
                }
            }
        }
    }
}
