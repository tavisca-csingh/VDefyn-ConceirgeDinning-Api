using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Core.ServicesImplementation
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
