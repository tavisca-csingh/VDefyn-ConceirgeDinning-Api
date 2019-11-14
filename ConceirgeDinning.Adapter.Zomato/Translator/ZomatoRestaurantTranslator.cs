using ConceirgeDinning.Adapter.Zomato.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurant = ConceirgeDinning.Contracts.Models.Restaurant;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoRestaurantTranslator
    {
        public static List<Restaurant> TranslateToRestaurant(this SearchResponse response)
        {
            List<Restaurant> responseObject = new List<Restaurant>();
            foreach (Models.Restaurant restaurant in response.restaurants)
            {

                responseObject.Add(new Restaurant()
                {
                    SupplierName = "Zomato",
                    RestaurantId = Convert.ToInt32(restaurant.restaurant.R.res_id),
                    RestaurantName = restaurant.restaurant.name,
                    LocalityVerbose = restaurant.restaurant.location.locality_verbose,
                    User_Rating = restaurant.restaurant.user_rating.aggregate_rating,
                    ThumbURL = restaurant.restaurant.thumb,
                    Cuisines = GetCuisines(restaurant.restaurant.cuisines),
                    PricePerHead = (restaurant.restaurant.average_cost_for_two/2).ToString(),
                    Latitude=restaurant.restaurant.location.latitude
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
