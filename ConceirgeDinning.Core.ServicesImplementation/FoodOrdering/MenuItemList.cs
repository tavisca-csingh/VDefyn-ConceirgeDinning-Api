using ConceirgeDinning.Adapter.Zomato;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.FoodOrdering
{
    public class MenuItemList
    {
        public List<MenuItem> GetMenus(string restaurantId, string supplierName)
        {
            if (supplierName is "Zomato")
            {
                ZomatoMenuItemAdpter zomatoMenu = new ZomatoMenuItemAdpter();
                return zomatoMenu.GetMenuItems(restaurantId);
            }
            return null;
        }
    }
}
