using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDinning.Core.Models;

namespace ConceirgeDinning.Services
{
    public interface IBookTable
    {
        List<Restaurant> fetchRestarauntDetails(string locality,string latitude,string longitude);
    }
}
