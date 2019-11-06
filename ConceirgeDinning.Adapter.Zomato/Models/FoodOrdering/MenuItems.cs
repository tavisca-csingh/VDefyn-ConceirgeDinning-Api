using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering
{
    public class Menu
    {
        public string id { get; set; }
        public string name { get; set; }
        public int position { get; set; }
        public string price { get; set; }
        public string consumable { get; set; }
        public string cuisine_name { get; set; }
        public string category_name { get; set; }
    }
    public class MenuItems
    {
        public List<Menu> menu { get; set; }
    }
}
