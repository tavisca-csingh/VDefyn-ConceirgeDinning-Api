using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;
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
            string supplierName = "Zomato";
            int restaurantId = 19160493;
            var restaurant= restaurantDetailsService.GetRestaurantDetails(restaurantId, supplierName);
            bool actual = restaurant is RestaurantDetails;
            Assert.True(actual);
        }

        [Fact]
        public void Get_Restaurant_Details_For_Invalid_Restaurant_Id()
        {
            string supplierName = "Zomato";
            int restaurantId = 123;
            var restaurant = restaurantDetailsService.GetRestaurantDetails(restaurantId, supplierName);
            bool actual = restaurant is null;
            Assert.True(actual);
        }

        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_SUPPLIER_NAME()
        {
            var result = restaurantDetailsService.GetRestaurantDetails(123, "Swiggy");
            Assert.Null(result);

        }
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_RESTAURANTID()
        {
            var result = restaurantDetailsService.GetRestaurantDetails(188217623, "Zomato");
            Assert.Null(result);
        }
        [Fact]
        public void SHOULD_RETURN_VALID_RESTAURANT_DETAILS_ON_PASSING_VALID_RESTAURANTID_AND_SUPPLIER_NAME()
        {
            var result = restaurantDetailsService.GetRestaurantDetails(18821762, "Zomato");

            Assert.Equal(18821762, result.RestaurantId);


        }
    }
}
