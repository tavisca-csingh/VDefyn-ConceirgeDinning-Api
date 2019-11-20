using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinningContracts.Services
{
    public interface IFetchRestaurantDetails
    {
        RestaurantDetails GetRestaurantDetails(int restaurantId);
    }
}
