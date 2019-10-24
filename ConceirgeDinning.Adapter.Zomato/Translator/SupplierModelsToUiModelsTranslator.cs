using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    class SupplierModelsToUiModelsTranslator
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

        public static RestaurantDetails TranslateToRestaurantDetails(Models.RestaurantDetails responseFromSupplier)
        {
            RestaurantDetails response = new RestaurantDetails();
            response.SupplierName = "Zomato";
            response.RestaurantName = responseFromSupplier.name;
            response.RestaurantId = Convert.ToInt32(responseFromSupplier.id);
            response.Address = responseFromSupplier.location.address;
            response.Cuisines = GetCuisines(responseFromSupplier.cuisines);
            response.User_Rating = responseFromSupplier.user_rating.aggregate_rating;
            response.PricePerHead = (responseFromSupplier.average_cost_for_two)/2;
            response.Images = GetImages(responseFromSupplier);
            response.Lat = responseFromSupplier.location.latitude;
            response.Lon = responseFromSupplier.location.longitude;
            
            return response;
            

        }
        public static List<string> GetImages(Models.RestaurantDetails responseFromSupplier)
        {
            List<string> RestaurantImages = new List<string>();
            if (responseFromSupplier.photos == null & responseFromSupplier.thumb == null)
                RestaurantImages.Add("https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg");
            else if (responseFromSupplier.photos == null & responseFromSupplier.thumb != null)
                RestaurantImages.Add(responseFromSupplier.thumb);

            else
            {
                int i = 0;
                foreach (var photo in responseFromSupplier.photos)
                {
                    if (i++ == 9)
                        break;
                    RestaurantImages.Add(photo.photo.url);
                }
            }
            return RestaurantImages;
        }
    }
}
