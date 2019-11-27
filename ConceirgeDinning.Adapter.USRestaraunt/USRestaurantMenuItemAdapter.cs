using ConceirgeDinning.Adapter.USRestaraunt.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt
{
    public class USRestaurantMenuItemAdapter
    {
        private readonly string _usrestaurantURL;
        private readonly string _usrestaurantKey;
        public USRestaurantMenuItemAdapter(string url, string key)
        {
            this._usrestaurantURL = url;
            this._usrestaurantKey = key;
        }
        public List<Category> GetMenuItems(string restaurantId)
        {
            var request = System.Net.WebRequest.Create(_usrestaurantURL+restaurantId);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", _usrestaurantKey);

            request.ContentType = "application/json";



            using (var response = request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        MenuItems menuItems = JsonConvert.DeserializeObject<MenuItems>(result);
                        Log.Information("response from supplier: " + JsonConvert.SerializeObject(result));
                        return menuItems.GetMenuItem();
                    }
                    catch (System.Net.WebException ex)
                    {
                        Log.Information("response from supplier: " + ex);
                        return null;
                    }
                }
            }
        }
    }
}
