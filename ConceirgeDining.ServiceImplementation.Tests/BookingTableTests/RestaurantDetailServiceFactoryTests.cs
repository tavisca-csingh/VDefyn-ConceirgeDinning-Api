using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConceirgeDining.ServiceImplementation.Tests.BookingTableTests
{

    public class RestaurantDetailServiceFactoryTests
    {


        RestaurantDetailServiceFactory restaurantDetailServiceFactory = new RestaurantDetailServiceFactory();

        [Fact]
        public void Check_For_Getting_Restaurant_Details_Factory_Adapter_For_Zomato()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            string supplierName = "Zomato";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName, options);
            bool actual = restaurantFactory is ZomatoRestaurantDetailsAdapter;
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Getting_Restaurant_Details_Factory_Adapter_For_USRestaurants()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                USrestaurantDetailsUrl = "https://us-restaurant-menus.p.rapidapi.com/restaurant/",
                USRestaurantKey = "01545b0594mshdb9591ceda3d162p1716b7jsn43e523b10b95",
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            string supplierName = "USRestaurant";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName, options);
            bool actual = restaurantFactory is USRestaurantDetailsAdapter;
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Getting_Restaurant_Details_Factory_Adapter_For_Invalid_Supplier()
        {
            AppSettingsModel appSettings = new AppSettingsModel()
            {
                ZomatoRestrauntdetailsUrl = "https://developers.zomato.com/api/v2.1/restaurant?res_id=",
                ZomatoKey = "2fb776134a7bcd1eaaacd639a90f87e7"
            };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            string supplierName = "UberEats";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName, options);
            bool actual = restaurantFactory is null;
            Assert.True(actual);
        }
    }
}
