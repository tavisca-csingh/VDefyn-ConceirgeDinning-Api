using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Services
{
    public interface IRestaurantByLocalityFetcher
    {
        List<Restaurant> FetchRestarauntDetails(LocalityGeocode locality);
    }
}
