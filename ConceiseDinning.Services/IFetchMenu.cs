using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinningContracts.Services
{
    public interface IFetchMenu
    {
        MenuItem GetMenu(string restaurantId, string supplierName);
    }
}
