using ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoMenuItemTranslator
    {
        public static List<MenuItem> GetMenuItem(Models.FoodOrdering.MenuItems menuItem)
        {

            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (Models.FoodOrdering.Category item in menuItem.categories)
            {
                foreach (Models.FoodOrdering.Menu Item in item.menuitems)
                {
                    menuItems.Add(new MenuItem()
                    {
                        Dish = Item.name,
                        Price = Item.price
                    });
                }
                
            }

            return menuItems;
        }
    }
}
