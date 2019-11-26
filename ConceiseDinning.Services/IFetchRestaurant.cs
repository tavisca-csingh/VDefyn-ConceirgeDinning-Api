using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinningContracts.Services
{
    public interface IFetchRestaurant
    {
        List<Restaurant> FetchRestarauntDetails(string latitude,string longitude,string category);
    }
}
