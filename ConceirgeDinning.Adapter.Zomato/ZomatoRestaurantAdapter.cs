using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Microsoft.Extensions.Configuration;
using Unity.Injection;
using System.Linq;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class ZomatoRestaurantAdapter : IFetchRestaurant
    {
        private readonly string _zomatoURL;
        private readonly string _zomatokey;

        public ZomatoRestaurantAdapter(string url,string key)
        {
            this._zomatoURL=url;
            this._zomatokey = key;
        }

        public List<Restaurant> FetchRestarauntDetails(string latitude, string longitude,string category)
        {
            var request = System.Net.WebRequest.Create(_zomatoURL + "&lat=" + latitude + "&lon=" + longitude+ "&category="+category);
            request.Method = "GET";
            request.Headers.Add("user-key", _zomatokey);

            request.ContentType = "application/json";
            using (var response = request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        var restrauntsList = JsonConvert.DeserializeObject<Models.SearchResponse>(result);
  
                        Log.Information("request to zomato: " + _zomatoURL + "&lat=" + latitude + "&lon=" + longitude + "&category=" + category+"\n response from supplier : " + JsonConvert.SerializeObject(result));
                        
                        return restrauntsList.TranslateToRestaurant();
                    }
                    catch (System.Net.WebException ex)
                    {
                        Log.Information("request to zomato: " + _zomatoURL + "&lat=" + latitude + "&lon=" + longitude + "&category=" + category+"\n response from supplier : " + ex );
                        return null;
                    }
                }
            }
        }
    }
}
