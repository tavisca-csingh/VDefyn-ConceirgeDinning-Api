using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
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
        private readonly string _zomatoURL;
        private readonly string _zomatoKey;

        public ZomatoRestaurantDetailsAdapter(string url,string key)
        {
            this._zomatoURL = url;
            this._zomatoKey = key;
        }
        public RestaurantDetails GetRestaurantDetails(int restaurantId)
        {
            var request = System.Net.WebRequest.Create(_zomatoURL + restaurantId);
            request.Method = "GET";
            request.Headers.Add("user-key", _zomatoKey);

            request.ContentType = "application/json";

            try
            {

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        Log.Information("request from user: "+restaurantId+"\n response to Zomato: "+ response.StatusCode);
                        return null;
                    }

                    using (var stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                        var result = reader.ReadToEnd();

                        Models.RestaurantDetails restaurantDetails = JsonConvert.DeserializeObject<Models.RestaurantDetails>(result);
                        var zomatoresponse = restaurantDetails.TranslateToRestaurantDetails();
                        Log.Information("request from user: " + restaurantId + "\n response from Zomato : " + JsonConvert.SerializeObject(zomatoresponse));
                        return zomatoresponse;
                        
                    }
                }
            }

            catch (System.Net.WebException ex)
            {
                Log.Information("request from user: " + restaurantId + "\n response from Zomato: " + ex);
                return null;
            }

        }
    }
}














          