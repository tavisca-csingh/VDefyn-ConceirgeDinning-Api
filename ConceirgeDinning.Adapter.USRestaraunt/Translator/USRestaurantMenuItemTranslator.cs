using ConceirgeDinning.Adapter.USRestaraunt.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Translator
{
    public static class USRestaurantMenuItemTranslator
    {
        public static List<Category> GetMenuItem(this MenuItems menuItem)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            List<Category> categoryList = new List<Category>();
            Category category = new Category();
            foreach (var item in menuItem.result.data)
            {
                menuItems = new List<MenuItem>();
                category = new Category();

                foreach (var Item in item.menu_item_pricing)
                {
                    menuItems.Add(new MenuItem()
                    {
                        Name = item.menu_item_name,
                        Price = Item.price.ToString()
                    });
                }
                category.category = item.subsection;
                category.Items = menuItems;
                categoryList.Add(category);
            }
            return categoryList;
        }
    }
}
