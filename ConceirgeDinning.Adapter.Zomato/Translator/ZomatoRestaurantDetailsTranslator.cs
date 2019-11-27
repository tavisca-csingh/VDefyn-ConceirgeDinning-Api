using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using PointConvertor = ConceirgeDinning.Contracts.Models.PointConverter;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoRestaurantDetailsTranslator
    {
        public static List<string> GetCuisines(string cuisines)
        {

            List<string> cuisinesList = new List<string>(cuisines.Split(", "));
            return cuisinesList;
        }

        public static RestaurantDetails TranslateToRestaurantDetails(this Models.RestaurantDetails responseFromSupplier)
        {
            int price = ((responseFromSupplier.average_cost_for_two) / 2) * PointConvertor.PointsConversionStandard["default"];

            RestaurantDetails response = new RestaurantDetails();
            response.SupplierName = "Zomato";
            response.RestaurantName = responseFromSupplier.name;
            response.RestaurantId = Convert.ToInt32(responseFromSupplier.id);
            response.Address = responseFromSupplier.location.address;
            response.Cuisines = GetCuisines(responseFromSupplier.cuisines);
            response.User_Rating = responseFromSupplier.user_rating.aggregate_rating;
            response.PricePerHead = price==0?100:price;
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
            if(responseFromSupplier.thumb=="")
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
