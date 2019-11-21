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
            var cuisine = new List<string>();
            foreach (var item in menuItem.result.data)
            {
                int flag = 0;
                if (!cuisine.Contains(item.subsection))
                {
                    menuItems = new List<MenuItem>();
                    category = new Category();
                    flag = 1;
                }

                menuItems.Add(new MenuItem()
                {
                    Name = item.menu_item_name,
                    Price = item.menu_item_pricing[0].price.ToString()
                });
                cuisine.Add(item.subsection);
                if (flag == 1)
                {
                    category.category = item.subsection;
                    category.Items = menuItems;
                    categoryList.Add(category);
                }
            }
            return categoryList;
        }
    }
}
