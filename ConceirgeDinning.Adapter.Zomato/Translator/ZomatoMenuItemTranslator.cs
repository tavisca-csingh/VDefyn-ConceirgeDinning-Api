using ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Category = ConceirgeDinning.Contracts.Models.Category;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoMenuItemTranslator
    {
        public static List<Category> GetMenuItem( this MenuItems menuItem)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            List<Contracts.Models.Category> categoryList = new List<Contracts.Models.Category>();
            Category category = new Category();
            foreach (var item in menuItem.categories)
            {
                menuItems = new List<MenuItem>();
                category = new Category();
                
                foreach (Menu Item in item.menuitems)
                {
                    menuItems.Add(new MenuItem()
                    {
                        Name = Item.name,
                        Price = Item.price
                    });
                }
                category.category = item.name;
                category.Items = menuItems;
                categoryList.Add(category);
            }
            return categoryList;
        }
    }
}
