using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class ZomatoRestaurantDetailsAdapter : IFetchRestaurantDetails
    {
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            string ApiUri = @"https://developers.zomato.com/api/v2.1/restaurant?res_id=";
            var request = System.Net.WebRequest.Create(ApiUri + restaurantId);
            request.Method = "GET";
            request.Headers.Add("user-key", "3d95592a1bf9c01986d17292db075163");

            request.ContentType = "application/json";

            try
            {

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        Log.Information("request to supplier: "+ response.StatusCode);
                        return null;
                    }

                    using (var stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                        var result = reader.ReadToEnd();

                        Models.RestaurantDetails restaurantDetails = JsonConvert.DeserializeObject<Models.RestaurantDetails>(result);
                        Log.Information("response from supplier :" + restaurantDetails);
                        return restaurantDetails.TranslateToRestaurantDetails();
                        
                    }
                }
            }

            catch (System.Net.WebException ex)
            {
                Log.Information("response from supplier: "+ex);
                return null;
            }

        }
    }
}














          