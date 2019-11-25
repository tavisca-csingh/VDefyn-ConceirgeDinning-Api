using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConceirgeDinning.API.Tests
{
    public class RestaurantListTest
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        public RestaurantListTest(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        [Fact]
        public void SHOULD_GIVE_RESTAURANTS_LIST_ON_GIVING_VALID_LOCALITY_FOR_BOOKING()
        {
            //GIVEN
            RestaurantList restaurant = new RestaurantList();
            var expected =10;
            //WHEN
            var actual = restaurant.FetchRestarauntDetails("pune",string.Empty,string.Empty,"2",appSettings).Count;
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
            var actual=restaurant.FetchRestarauntDetails(string.Empty, "18.4", "76.5", "1",appSettings).Count;
            //then
            Assert.Equal(expected,actual);

        }

    }
}
