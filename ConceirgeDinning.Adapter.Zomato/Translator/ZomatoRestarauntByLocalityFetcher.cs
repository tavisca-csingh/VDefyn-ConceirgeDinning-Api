using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class ZomatoRestarauntByLocalityFetcher:IRestaurantByLocalityFetcher
    {
        public List<Restaurant> FetchRestarauntDetails(LocalityGeocode locality)
        {
            string ApiUri = @"https://developers.zomato.com/api/v2.1/search?count=10&category=2&radius=1500&sort=real_distance";
            var request = System.Net.WebRequest.Create(ApiUri + "&lat=" + locality.Latitude + "&lon=" + locality.Longitude);
            request.Method = "GET";
            request.Headers.Add("user-key", "3d95592a1bf9c01986d17292db075163");

            request.ContentType = "application/json";


            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();

                    Models.SearchResponse Response = JsonConvert.DeserializeObject<Models.SearchResponse>(result);
                    
                   

                    var searchResults = SupplierModelsToUiModelsTranslator.TranslateToRestaurant(Response);







                  
                    return searchResults;
                }
            }

        }
    }
}
