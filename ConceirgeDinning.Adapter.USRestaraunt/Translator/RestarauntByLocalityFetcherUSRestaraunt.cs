using ConceirgeDinning.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConceirgeDinning.Adapter.USRestaraunt.Models;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class RestarauntByLocalityFetcherUSRestaraunt
    {
        public List<RestarauntDetails> FetchRestarauntDetails(double Latitude, double Longitude, string CountryName)
        {
            WebClient client = new WebClient();
            RestarauntDetails restarauntDetails = new RestarauntDetails();
            List<RestarauntDetails> restaraunts = new List<RestarauntDetails>();
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance=2";
            var request = System.Net.WebRequest.Create(ApiUri + "&lat=" + Latitude + "&lon=" + Longitude);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "0416d26f02msh589cf430c166051p1c0a3djsn6029f7f1a261");
            request.ContentType = "application/json";
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
            string responseFromServer = reader.ReadToEnd();
                // Display the content.  
            var jobject=JsonConvert.DeserializeObject<RestarauntByLocality>(responseFromServer);
            foreach (var item in jobject.result.data)
            {
                restaraunts.Add(new RestarauntDetails()
                {
                    RestarauntId = item.restaurant_id,
                    RestarauntName = item.restaurant_name,
                    RestarauntAddress = item.address.street + "," + item.address.city,
                    SupplierName = "USRestaraunt",
                    Cuisines = item.cuisines,
                    User_Rating=4.1
                }) ;

            }
            return restaraunts;
            

        }
    }
}
