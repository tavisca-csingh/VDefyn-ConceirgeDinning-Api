using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoRestaurantTranslator
    {
        public static List<Restaurant> GetRestaraunts(Models.ZomatoRestaurant jobject)
        {
            Restaurant restaraunt = new Restaurant();
            List<Restaurant> restaraunts = new List<Restaurant>();
            foreach (var item in jobject.restaurants)
            {
                List<object> cusineList = new List<object>();
                cusineList.Add(item.restaurant.cuisines);
                restaraunts.Add(new Restaurant()
                {

                    RestaurantName = item.restaurant.name,
                    RestaurantId = item.restaurant.id,
                    SupplierName = "Zomato",
                    RestaurantAddress = item.restaurant.location.locality + "," + item.restaurant.location.city,
                    ThumbURL = item.restaurant.thumb == string.Empty ? "https://icon-library.net/images/no-image-available-icon/no-image-available-icon-6.jpg" : item.restaurant.thumb,
                    User_Rating = item.restaurant.user_rating.aggregate_rating,
                    Cuisines = cusineList,
                    Latitude=item.restaurant.location.latitude,
                    Longitude=item.restaurant.location.longitude

                });
            }
            return restaraunts;
        }
    }
}
