using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class ZomatoRestaurantAdapter : IFetchRestaurant
    {
        public List<Restaurant> FetchRestarauntDetails(string latitude, string longitude,string category)
        {
            string ApiUrl = @"https://developers.zomato.com/api/v2.1/search?count=10&radius=2000&sort=real_distance";
            var request = System.Net.WebRequest.Create(ApiUrl + "&lat=" + latitude + "&lon=" + longitude+ "&category="+category);
            request.Method = "GET";
            request.Headers.Add("user-key", "3d95592a1bf9c01986d17292db075163");

            request.ContentType = "application/json";


            using (var response = request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        var jobject = JsonConvert.DeserializeObject<Models.SearchResponse>(result);
                        Log.Information(",No. of fetched restaurantlist: " + result + "\n");
                        return ZomatoRestaurantTranslator.TranslateToRestaurant(jobject);
                    }
                    catch (System.Net.WebException ex)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
