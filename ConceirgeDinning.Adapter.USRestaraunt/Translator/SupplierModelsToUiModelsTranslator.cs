
using ConceirgeDinning.Adapter.USRestaraunt.Models;
using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Restaurant = ConceirgeDinning.Core.Models.Restaurant;
using RestaurantDetails = ConceirgeDinning.Core.Models.RestaurantDetails;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    class SupplierModelsToUiModelsTranslator
    {
        public static List<Restaurant> TranslateToRestaurant(Models.SearchResponse response)
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

        public static RestaurantDetails TranslateToRestaurantDetails(RestaurantDetailResponse responseFromSupplier)
        {
            if (responseFromSupplier.result.totalResults == 0)
                return null;
            RestaurantDetails response = new RestaurantDetails();
            response.SupplierName = "USRestaurant";
            response.RestaurantName = responseFromSupplier.result.data[0].restaurant_name;
            response.RestaurantId = responseFromSupplier.result.data[0].restaurant_id;
            response.PricePerHead = GetPrice(responseFromSupplier.result.data[0].price_range);
            response.User_Rating = GetRating(3,5);
            response.Cuisines = responseFromSupplier.result.data[0].cuisines;
            response.Address = responseFromSupplier.result.data[0].address.formatted;
            response.Images = new List<string>(){ "https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg"};
            response.Lat=responseFromSupplier.result.data[0].geo.lat.ToString();
            response.Lon = responseFromSupplier.result.data[0].geo.lon.ToString();

            return response;
        }

        private static int GetPrice(string price_range)
        {
            return price_range.Length * 10;
        }
    }
}

