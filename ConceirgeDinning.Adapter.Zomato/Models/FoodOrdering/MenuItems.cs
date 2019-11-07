using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering
{
    public class Discount
    {
        public string type { get; set; }
        public string amount { get; set; }
    }

    public class Subitem
    {
        public string id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string price { get; set; }
        public string consumable { get; set; }
        public string cuisinename { get; set; }
        public string categoryname { get; set; }
        public Discount discount { get; set; }
        public List<object> tags { get; set; }
    }

    public class Menu
    {
        public string id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public List<Subitem> subitems { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public List<Menu> menuitems { get; set; }
    }

    public class MenuItems
    {
        public List<Category> categories { get; set; }
    }
}

