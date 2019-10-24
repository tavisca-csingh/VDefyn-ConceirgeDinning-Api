using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Services
{
    public interface IFetchGeocode
    {
        LocalityGeocode GetRestaurantGeocode(string locality);
    }
}
