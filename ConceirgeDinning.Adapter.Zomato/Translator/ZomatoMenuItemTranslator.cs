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
        public static List<Category> GetMenuItem(Models.FoodOrdering.MenuItems menuItem)
        {

            List<MenuItem> menuItems = new List<MenuItem>();
            List<Contracts.Models.Category> category = new List<Contracts.Models.Category>();
            Category cat = new Category();
            foreach (var item in menuItem.categories)
            {
                menuItems = new List<MenuItem>();
                cat = new Category();
                cat.category = item.name;

                foreach (Models.FoodOrdering.Menu Item in item.menuitems)
                {
                    menuItems.Add(new MenuItem()
                    {
                        Name = Item.name,
                        Price = Item.price
                    });
                }
                cat.Items = menuItems;
                category.Add(cat);
               

            }
           /* foreach(Models.FoodOrdering.Category item in menuItem.categories)
            {
                category.Add(new Contracts.Models.Category()
                {
                    category=item.name,
                    Items=menuItems
                });
            }*/

            return category;
        }
    }
}
