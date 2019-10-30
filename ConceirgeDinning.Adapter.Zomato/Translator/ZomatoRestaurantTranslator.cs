using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    class ZomatoRestaurantTranslator
    {
        public static List<Restaurant> TranslateToRestaurant(Models.SearchResponse response)
        {
            List<Restaurant> responseObject = new List<Restaurant>();
            foreach (Models.Restaurant restaurant in response.restaurants)
            {

                responseObject.Add(new Restaurant()
                {
                    SupplierName = "Zomato",
                    RestaurantId = Convert.ToInt32(restaurant.restaurant.id),
                    RestaurantName = restaurant.restaurant.name,
                    LocalityVerbose = restaurant.restaurant.location.locality_verbose,
                    User_Rating = restaurant.restaurant.user_rating.aggregate_rating,
                    ThumbURL = restaurant.restaurant.thumb,
                    Cuisines = GetCuisines(restaurant.restaurant.cuisines)

                });

            }
            return responseObject;
        }
        public static List<String> GetCuisines(string cuisines)
        {
            List<string> cuisinesList = new List<string>(cuisines.Split(", "));
            return cuisinesList;
        }

        
    }
}
