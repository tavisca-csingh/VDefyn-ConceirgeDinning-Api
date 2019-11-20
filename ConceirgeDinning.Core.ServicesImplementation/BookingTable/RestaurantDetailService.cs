using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class RestaurantDetailService
    {
        public RestaurantDetails GetRestaurantDetails(int restaurantId,string supplierName)
        {
            RestaurantDetailServiceFactory Factory = new RestaurantDetailServiceFactory();
           
            IFetchRestaurantDetails RestaurantDetailService = Factory.GetRestaurantDetailService(supplierName);
            if (RestaurantDetailService == null)
                return null;
            else
                return RestaurantDetailService.GetRestaurantDetails(restaurantId);
            
        }
    }
}
