using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConceirgeDining.ServiceImplementation.Tests.BookingTableTests
{
    public class RestaurantDetailsServiceTests
    {

        RestaurantDetailService restaurantDetailsService = new RestaurantDetailService();
        [Fact]
        public void Get_Restaurant_Details_For_Valid_Restaurant_Id()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl= "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            string supplierName = "Zomato";
            int restaurantId = 19160493;
            var restaurant= restaurantDetailsService.GetRestaurantDetails(restaurantId, supplierName,options);
            bool actual = restaurant is RestaurantDetails;
            Assert.True(actual);
        }

        [Fact]
        public void Get_Restaurant_Details_For_Invalid_Restaurant_Id()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            string supplierName = "Zomato";
            int restaurantId = 123;
            var restaurant = restaurantDetailsService.GetRestaurantDetails(restaurantId, supplierName,options);
            bool actual = restaurant is null;
            Assert.True(actual);
        }

        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_SUPPLIER_NAME()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var result = restaurantDetailsService.GetRestaurantDetails(123, "Swiggy",options);
            Assert.Null(result);

        }
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_RESTAURANTID()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var result = restaurantDetailsService.GetRestaurantDetails(188217623, "Zomato",options);
            Assert.Null(result);
        }
        [Fact]
        public void SHOULD_RETURN_VALID_RESTAURANT_DETAILS_ON_PASSING_VALID_RESTAURANTID_AND_SUPPLIER_NAME()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var result = restaurantDetailsService.GetRestaurantDetails(18821762, "Zomato",options);

            Assert.Equal(18821762, result.RestaurantId);


        }
    }
}
