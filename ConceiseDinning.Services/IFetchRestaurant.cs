using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Services
{
    public interface IFetchRestaurant
    {
        List<Restaurant> FetchRestarauntDetails(string latitude,string longitude,string category);
    }
}
