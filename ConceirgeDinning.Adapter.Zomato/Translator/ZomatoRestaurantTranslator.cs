using ConceirgeDinning.Adapter.Zomato;
using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDinning.Contracts.Models;
using PointConvertor = ConceirgeDinning.Contracts.Models.PointConverter;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoRestaurantTranslator
    {
        public static List<Restaurant> TranslateToRestaurant(this Models.SearchResponse response)
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
                    ThumbURL = restaurant.restaurant.thumb==""?"https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg":restaurant.restaurant.thumb,
                    Cuisines = GetCuisines(restaurant.restaurant.cuisines),
                    PricePerHead = ((restaurant.restaurant.average_cost_for_two/2)*PointConvertor.PointsConversionStandard["default"]).ToString(),
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
