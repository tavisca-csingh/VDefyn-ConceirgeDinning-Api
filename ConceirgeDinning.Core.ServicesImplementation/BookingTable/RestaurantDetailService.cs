using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class RestaurantDetailService
    {
        
        public RestaurantDetails GetRestaurantDetails(int restaurantId,string supplierName,IOptions<AppSettingsModel> appsettings)
        {
            try
            {
                RestaurantDetailServiceFactory Factory = new RestaurantDetailServiceFactory();

                IFetchRestaurantDetails RestaurantDetailService = Factory.GetRestaurantDetailService(supplierName, appsettings);
                if (RestaurantDetailService == null)
                    return null;
                else
                    return RestaurantDetailService.GetRestaurantDetails(restaurantId);
            }
            catch (Exception e )
            {

                throw e;
            }
            
            
        }
    }
}
