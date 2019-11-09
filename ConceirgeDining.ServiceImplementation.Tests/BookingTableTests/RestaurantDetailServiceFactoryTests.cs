using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Core.ServicesImplementation;
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
            string supplierName = "Zomato";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName);
            bool actual = restaurantFactory is ZomatoRestaurantDetailsAdapter;
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Getting_Restaurant_Details_Factory_Adapter_For_USRestaurants()
        {
            string supplierName = "USRestaurant";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName);
            bool actual = restaurantFactory is USRestaurantDetailsAdapter;
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Getting_Restaurant_Details_Factory_Adapter_For_Invalid_Supplier()
        {
            string supplierName = "UberEats";
            var restaurantFactory = restaurantDetailServiceFactory.GetRestaurantDetailService(supplierName);
            bool actual = restaurantFactory is null;
            Assert.True(actual);
        }
    }
}
