using System;
using Xunit;
using Moq;

using ConceirgeDinning.ServicesImplementation.BookingTable;
using ConceirgeDinning.Contracts.Models;
using Microsoft.Extensions.Options;

namespace ConceirgeDinning.ServiceImplementation.Test

{
    public class RestaurantDetailTest
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        public RestaurantDetailTest(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_SUPPLIER_NAME()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(123, "Swiggy",appSettings);
            Assert.Null(result);
            
        }
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_RESTAURANTID()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(188217623, "Zomato",appSettings);
            Assert.Null(result);
        }
        [Fact]
        public void SHOULD_RETURN_VALID_RESTAURANT_DETAILS_ON_PASSING_VALID_RESTAURANTID_AND_SUPPLIER_NAME()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(18821762, "Zomato",appSettings);
            
            Assert.Equal(18821762,result.RestaurantId);


        }
    }
}
