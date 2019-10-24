using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Services
{
    public interface IFetchRestaurant
    {
        List<Restaurant> GetRestaurant(LocalityGeocode restaurantGeocode);
    }
}
