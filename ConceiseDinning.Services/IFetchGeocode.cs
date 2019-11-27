using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDinning.Contracts.Models;

namespace ConceirgeDinningContracts.Services
{
    public interface IFetchGeocode
    {
        LocalityGeocode FetchCoordinates(string locality,string latitude,string longitude);
    }
}
