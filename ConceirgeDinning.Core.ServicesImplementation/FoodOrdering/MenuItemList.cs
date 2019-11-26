using ConceirgeDinning.Adapter.Zomato;
using ConceirgeDinning.Adapter.USRestaraunt;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace ConceirgeDinning.ServicesImplementation.FoodOrdering
{
    public class MenuItemList
    {
        public List<Category> GetMenus(string restaurantId, string supplierName, IOptions<AppSettingsModel> appSettings)
        {
            if (supplierName is "Zomato")
            {
                ZomatoMenuItemAdpter zomatoMenu = new ZomatoMenuItemAdpter(appSettings.Value.ZomatoMenuItemUrl);
                return zomatoMenu.GetMenuItems(restaurantId);
            }
            /*else if(supplierName is "USRestaraunt")
            {
                USRestaurantMenuItemAdapter usRestaurantAdapter = new USRestaurantMenuItemAdapter();
                return usRestaurantAdapter.GetMenuItems(restaurantId);
            }*/
            return null;
        }
    }
}
