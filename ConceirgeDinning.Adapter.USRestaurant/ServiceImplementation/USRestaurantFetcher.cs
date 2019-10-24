using ConceirgeDinning.Adapter.USRestaurant.Models;
using ConceirgeDinning.Adapter.USRestaurant.Translator;
using ConceirgeDinning.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConceirgeDinning.Contracts.Services;

namespace ConceirgeDinning.Adapter.USRestaurant.ServiceImplementation
{
    public class USRestaurantFetcher:IFetchRestaurant
    {
        
        public List<Restaurant> GetRestaurant(LocalityGeocode restaurantGeocode)
        {
            
            string ApiUrl = @"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance=2";
            var request = System.Net.WebRequest.Create(ApiUrl + "&lat=" + restaurantGeocode.Latitude + "&lon=" + restaurantGeocode.Longitude);
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


            var jobject = JsonConvert.DeserializeObject<Models.USRestaurant>(responseFromServer);
            return USRestaurantTranslator.GetRestaurants(jobject); 
        }
    }
}
