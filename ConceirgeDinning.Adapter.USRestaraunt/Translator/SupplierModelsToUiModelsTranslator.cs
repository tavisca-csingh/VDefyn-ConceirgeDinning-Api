
using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    class SupplierModelsToUiModelsTranslator
    {
        public static List<Restaurant> Translate(Models.SearchResponse response)
        {
            List<Restaurant> restaurantList = new List<Restaurant>();
            foreach (var restaurant in response.result.data)
            {
                restaurantList.Add(new Restaurant()
                {
                    SupplierName = "USRestaurant",
                    RestaurantId = restaurant.restaurant_id,
                    RestaurantName = restaurant.restaurant_name,
                    ThumbURL = "https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg",
                    User_Rating = GetRating(3, 5),
                    LocalityVerbose = restaurant.address.street + ", " + restaurant.address.city,
                    Cuisines = restaurant.cuisines
                });
            }
            return restaurantList;


        }

        public static string GetRating(int minimumValue, int maximumValue)
        {
            Random random = new Random();
            return (Math.Round(random.NextDouble(), 1) * (maximumValue - minimumValue) + minimumValue).ToString();
        }
    }
}

