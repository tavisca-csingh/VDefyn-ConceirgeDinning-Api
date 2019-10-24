using System;
using Xunit;
using Moq;
using ConceirgeDinning.Core.ServicesImplementation;
using ConceirgeDinning.Core.Models;

namespace ConceirgeDinning.Core.ServiceImplementation.Test
{
    public class RsetaurantDetailService
    {
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_SUPPLIER_NAME()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(123, "Swiggy");
            Assert.Equal(result,null);
            
        }
        [Fact]
        public void SHOULD_RETURN_NULL_ON_PASSING_INVALID_RESTAURANTID()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(188217623, "Zomato");
            Assert.Equal(result, null);
        }
        [Fact]
        public void SHOULD_RETURN_VALID_RESTAURANT_DETAILS_ON_PASSING_VALID_RESTAURANTID_AND_SUPPLIER_NAME()
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            var result = restaurantDetailService.GetRestaurantDetails(18821762, "Zomato");
            
            Assert.Equal(result.RestaurantId, 18821762);


        }
    }
}
