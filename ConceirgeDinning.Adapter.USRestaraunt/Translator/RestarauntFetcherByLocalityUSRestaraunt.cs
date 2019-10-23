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
    public class RestarauntFetcherByLocalityUSRestaraunt
    {
        public List<Core.Models.RestarauntByLocality> FetchRestarauntDetails(double Latitude, double Longitude, string CountryName)
        {
            Core.Models.RestarauntByLocality restarauntDetails = new Core.Models.RestarauntByLocality();
            List<Core.Models.RestarauntByLocality> restaraunts = new List<Core.Models.RestarauntByLocality>();


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


            var jobject= JsonConvert.DeserializeObject<Models.RestarauntByLocalityUSRestaraunt>(responseFromServer);
            Random random = new Random();
            
            foreach (var item in jobject.result.data)
            {
                var rating = random.NextDouble() * (5.0 - 4.0) + 4.0;
                restaraunts.Add(new Core.Models.RestarauntByLocality()
                {
                    RestarauntId = item.restaurant_id,
                    RestarauntName = item.restaurant_name,
                    RestarauntAddress = item.address.street + "," + item.address.city,
                    SupplierName = "USRestaraunt",
                    Cuisines = item.cuisines,
                    User_Rating = Math.Round(rating,1)
                }) ;

            }
           return restaraunts;
            

        }
    }
}
