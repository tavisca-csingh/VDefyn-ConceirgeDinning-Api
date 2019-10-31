
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public class USRestarauntAdapter : IFetchRestaurant
    {
        public List<Restaurant> FetchRestarauntDetails(string latitude,string longitude)
        {
            string ApiUri = @"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance=2";
            var request = System.Net.WebRequest.Create(ApiUri + "&lat=" + latitude + "&lon=" + longitude);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "01545b0594mshdb9591ceda3d162p1716b7jsn43e523b10b95");

            request.ContentType = "application/json";

            
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();

                    Models.SearchResponse Response = JsonConvert.DeserializeObject<Models.SearchResponse>(result);
                    
                    var searchResults = USReataurantTranslator.TranslateToRestaurant(Response);
                    return searchResults;
                }
            }


        }
    }
}
