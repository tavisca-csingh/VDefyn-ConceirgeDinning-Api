using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConceirgeDinning.API.Tests
{
    public class RestaurantListTest
    {
        [Fact]
        public void SHOULD_GIVE_NOTHING_ON_GIVING_INVALID_LOCALITY_FOR_BOOKING()
        {
            //GIVEN
            RestaurantList restaurant = new RestaurantList();
            //WHEN
            var expected = restaurant.FetchRestarauntDetails("xyz", string.Empty, string.Empty, "1");
            //THEN
            Assert.Null(expected);
        }
        [Fact]
        public void SHOULD_GIVE_RESTAURANTS_LIST_ON_GIVING_VALID_LOCALITY_FOR_BOOKING()
        {
            //GIVEN
            RestaurantList restaurant = new RestaurantList();
            var expected =10;
            //WHEN
            var actual = restaurant.FetchRestarauntDetails("pune",string.Empty,string.Empty,"2").Count;
            //THEN
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SHOULD_GIVE_RESTAURANT_LIST_ON_GIVING_VALID_LATLONG_FOR_BOOKING()
        {
            //given
            RestaurantList restaurant = new RestaurantList();
            var expected = 10;
            //when
            var actual=restaurant.FetchRestarauntDetails(string.Empty, "18.4", "76.5", "1").Count;
            //then
            Assert.Equal(expected,actual);

        }

    }
}
