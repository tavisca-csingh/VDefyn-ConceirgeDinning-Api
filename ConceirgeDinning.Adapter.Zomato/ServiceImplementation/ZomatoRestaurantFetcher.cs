using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ConceirgeDinning.Contracts.Services;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.ServiceImplementation
{
    public class ZomatoRestaurantFetcher : IFetchRestaurant
    {
        public List<Restaurant> GetRestaurant(LocalityGeocode localityGeocode)
        {


            string ApiUrl = "https://developers.zomato.com/api/v2.1/search?count=10&category=2&radius=1500&sort=real_distance";
            var request = System.Net.WebRequest.Create(ApiUrl + "&lat=" + localityGeocode.Latitude + "&lon=" + localityGeocode.Longitude);
            request.Method = "GET";
            request.Headers.Add("user-key", "3d95592a1bf9c01986d17292db075163");
            request.ContentType = "application/json";

            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            var jobject = JsonConvert.DeserializeObject<Models.ZomatoRestaurant>(responseFromServer);
            return ZomatoRestaurantTranslator.GetRestaraunts(jobject);


        }
    }
}
