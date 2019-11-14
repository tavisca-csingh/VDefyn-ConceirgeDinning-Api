using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinningContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class RestaurantDetailServiceFactory
    {
        public IFetchRestaurantDetails GetRestaurantDetailService(string supplierName)
        {

            if (supplierName == "Zomato")
                return new ZomatoRestaurantDetailsAdapter();
            else if (supplierName == "USRestaurant")
                return new USRestaurantDetailsAdapter();
            else
                return null;
        }
    }
}
