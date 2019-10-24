using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class RestaurantDetailServiceFactory
    {
        public IRestaurantDetailService GetRestaurantDetailService(string supplierName)
        {

            if (supplierName == "Zomato")
                return new ZomatoRestaurantDetailService();
            else if (supplierName == "USRestaurant")
                return new USRestaurantDetailService();
            else
                return null;
        }
    }
}
