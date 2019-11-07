using ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Contracts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Category = ConceirgeDinning.Contracts.Models.Category;

namespace ConceirgeDinning.Adapter.Zomato
{
    public class ZomatoMenuItemAdpter
    {
        public List<Category> GetMenuItems(string restaurantId)
        {
            string ApiUrl = @"http://demo9372501.mockable.io/menuitem";
            var request = System.Net.WebRequest.Create(ApiUrl);
            request.Method = "GET";

            request.ContentType = "application/json";
            


            using (var response = request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        MenuItems jobject = JsonConvert.DeserializeObject<MenuItems>(result);
                        return ZomatoMenuItemTranslator.GetMenuItem(jobject);
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
