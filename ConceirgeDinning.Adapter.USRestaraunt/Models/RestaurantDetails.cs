using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models
{
    public class RestaurantDetails
    {
        public Geo geo { get; set; }
        
        public Address address { get; set; }
        public string restaurant_phone { get; set; }
        public int restaurant_id { get; set; }
        public string price_range { get; set; }
       
        public List<string> cuisines { get; set; }
        public string restaurant_name { get; set; }
        public int item_id { get; set; }
        public string menu_item_description { get; set; }
        public string menu_item_name { get; set; }
        public List<object> menu_item_pricing { get; set; }
        public string restaurant_hours { get; set; }
        public string subsection { get; set; }
        public string subsection_description { get; set; }
    }
}