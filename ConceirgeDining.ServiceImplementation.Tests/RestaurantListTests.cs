using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options.Options;
using Xunit;
using System.Configuration;

namespace ConceirgeDining.Services.ServiceImplementation.Tests
{
    public class RestaurantListTests
    {
        //private readonly IOptions<AppSettingsModel> appSettings;

        RestaurantList restaurantList = new RestaurantList();
        [Fact]
        public void Get_Restaurant_List_By_Locality_For_Table_Booking()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                GoogleGeocodeURL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=",
                GoogleGeocodeKey = "AIzaSyDk4DLNBHpQUDvLmRYcPVrq3uwNmGesZT4",
                ZomatoURL = "https://developers.zomato.com/api/v2.1/search?count=10&radius=2000&sort=real_distance",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var resList = restaurantList.FetchRestarauntDetails("Pune", "", "", "2", options);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
        [Fact]
        public void Get_Restaurant_List_By_LatLng_For_Table_Booking()
        {
            AppSettingsModel appSettings = new AppSettingsModel() { ZomatoURL = "https://developers.zomato.com/api/v2.1/search?count=10&radius=2000&sort=real_distance", ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7" };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var resList = restaurantList.FetchRestarauntDetails("", "77.5011", "77.5011", "2", options);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
        [Fact]
        public void Get_Restaurant_List_By_Locality_For_Food_Ordering()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                GoogleGeocodeURL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=",
                GoogleGeocodeKey = "AIzaSyDk4DLNBHpQUDvLmRYcPVrq3uwNmGesZT4",
                ZomatoURL = "https://developers.zomato.com/api/v2.1/search?count=10&radius=2000&sort=real_distance",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var resList = restaurantList.FetchRestarauntDetails("Pune", "", "", "1", options);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);
        }

        [Fact]
        public void Get_Restaurant_List_By_LatLng_For_Food_Ordering()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoURL = "https://developers.zomato.com/api/v2.1/search?count=10&radius=2000&sort=real_distance",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            var resList = restaurantList.FetchRestarauntDetails("", "27.2038", "77.5011", "1", options);
            bool actual = resList is List<Restaurant>;
            Assert.True(actual);

        }
    }
}
