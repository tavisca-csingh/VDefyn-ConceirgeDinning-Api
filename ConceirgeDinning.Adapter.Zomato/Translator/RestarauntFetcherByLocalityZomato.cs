using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using ConceirgeDinning.Adapter.Zomato.Models;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public class RestarauntFetcherByLocalityZomato
    {
        public List<Core.Models.RestarauntByLocality> FetchRestarauntDetails(double Latitude, double Longitude, string CountryName)
        {

            Core.Models.RestarauntByLocality restarauntDetails = new Core.Models.RestarauntByLocality();
            List<Core.Models.RestarauntByLocality> restaraunts = new List<Core.Models.RestarauntByLocality>();
            
            string ApiUrl ="https://developers.zomato.com/api/v2.1/search?count=10&category=2&radius=1500&sort=real_distance";
            var request = System.Net.WebRequest.Create(ApiUrl + "&lat=" + Latitude + "&lon=" + Longitude);
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
            var jobject = JsonConvert.DeserializeObject<Models.RestarauntByLocalityZomato>(responseFromServer);

            foreach (var item in jobject.restaurants)
            {
                List<object> cusineList = new List<object>();
                cusineList.Add(item.restaurant.cuisines);
                restaraunts.Add(new Core.Models.RestarauntByLocality()
                {

                    RestarauntName = item.restaurant.name,
                    RestarauntId = Convert.ToInt32(item.restaurant.id),
                    SupplierName = "Zomato",
                    RestarauntAddress = item.restaurant.location.locality + "," + item.restaurant.location.city,
                    ThumbURL = item.restaurant.thumb,
                    User_Rating = Convert.ToDouble(item.restaurant.user_rating.aggregate_rating),
                    Cuisines = cusineList

                }) ;
            }
            return restaraunts;
        }
    }
}
