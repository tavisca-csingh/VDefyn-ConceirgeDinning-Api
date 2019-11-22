using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class RestaurantDetailServiceFactory
    {
        public IFetchRestaurantDetails GetRestaurantDetailService(string supplierName,IOptions<AppSettingsModel> appsetting)
        {

            if (supplierName == "Zomato")
                return new ZomatoRestaurantDetailsAdapter(appsetting.Value.ZomatoRestrauntdetailsUrl,appsetting.Value.ZomatoKey);
            else if (supplierName == "USRestaurant")
                return new USRestaurantDetailsAdapter(appsetting.Value.USrestaurantDetailsUrl,appsetting.Value.USRestaurantKey);
            else
                return null;
        }
    }
}
