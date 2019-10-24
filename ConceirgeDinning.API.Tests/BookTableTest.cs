using ConceirgeDinning.Contracts.Models;
using RestaurantForBookingTable.cs;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConceirgeDinning.API.Tests
{
    public class BookTableTest
    {
        [Fact]
        public void When_Given_InvalidLocality()
        {
            //when
            RestaurantForTableBooking restaurantForTableBooking = new RestaurantForTableBooking();
            //given
            var actual = restaurantForTableBooking.GetRestaurants("jfsdnnsk");
            object expected = null;
            //then
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void When_Given_LocalityFromUs()
        {
            //when
            RestaurantForTableBooking restaurantForTableBooking = new RestaurantForTableBooking();
            //given
            var actual = restaurantForTableBooking.GetRestaurants("New York").Capacity;
            var expected = 60;
            
            //then
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void When_Given_LocalityOutsideOfUS()
        {
            //when
            RestaurantForTableBooking restaurantForTableBooking = new RestaurantForTableBooking();
            //given
            var actual = restaurantForTableBooking.GetRestaurants("Viman Nagar Pune").Capacity;
            var expected = 16;
            //then
            Assert.Equal(expected, actual);
        }
    }
}
