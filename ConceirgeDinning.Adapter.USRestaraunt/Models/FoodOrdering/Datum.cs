using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models.FoodOrdering
{
    public class Datum
    {
        public Address address { get; set; }
        public List<string> cuisines { get; set; }
        public Geo geo { get; set; }
        public int item_id { get; set; }
        public string menu_item_description { get; set; }
        public string menu_item_name { get; set; }
        public List<MenuItemPricing> menu_item_pricing { get; set; }
        public string price_range { get; set; }
        public string restaurant_hours { get; set; }
        public int restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string restaurant_phone { get; set; }
        public string subsection { get; set; }
        public string subsection_description { get; set; }
    }
}
