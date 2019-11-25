using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Xunit;

namespace ConceirgeDining.Services.ServiceImplementation.Tests
{
    public class RestaurantListTests
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        public RestaurantListTests(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        RestaurantList restaurantList = new RestaurantList();
        [Fact]
        public void Get_Restaurant_List_By_Locality_For_Table_Booking()
        {
            var resList=restaurantList.FetchRestarauntDetails("Pune", "", "", "2",appSettings);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
        [Fact]
        public void Get_Restaurant_List_By_LatLng_For_Table_Booking()
        {
            var resList = restaurantList.FetchRestarauntDetails("", "77.5011", "77.5011", "2",appSettings);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
        [Fact]
        public void Get_Restaurant_List_By_Locality_For_Food_Ordering()
        {
            var resList = restaurantList.FetchRestarauntDetails("Pune", "", "", "1",appSettings);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
        [Fact]
        public void Get_Restaurant_List_By_LatLng_For_Food_Ordering()
        {
            var resList = restaurantList.FetchRestarauntDetails("", "27.2038", "77.5011", "1",appSettings);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
    }
}
