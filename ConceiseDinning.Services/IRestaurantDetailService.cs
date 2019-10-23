using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Services
{
    public interface IRestaurantDetailService
    {
        RestaurantDetails GetRestaurantDetails(int restaurantId);
    }
}
