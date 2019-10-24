using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaurant.Translator
{
    public static class USRestaurantTranslator
    {
        public static List<Restaurant> GetRestaurants(Models.USRestaurant jobject)
        {
            Restaurant restarauntDetails = new Restaurant();
            List<Restaurant> restaraunts = new List<Restaurant>();
            Random random = new Random();

            foreach (var item in jobject.result.data)
            {
                var rating = random.NextDouble() * (5.0 - 4.0) + 4.0;
                restaraunts.Add(new Restaurant()
                {

                    RestaurantId = item.restaurant_id.ToString(),
                    RestaurantName = item.restaurant_name,
                    RestaurantAddress = item.address.street + "," + item.address.city,
                    SupplierName = "USRestaraunt",
                    Cuisines = item.cuisines,
                    User_Rating = Math.Round(rating, 1).ToString(),
                    ThumbURL = "https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg",
                    Latitude = item.geo.lat.ToString(),
                    Longitude = item.geo.lon.ToString()


                });

            }
            return restaraunts;
        }
    }
}
