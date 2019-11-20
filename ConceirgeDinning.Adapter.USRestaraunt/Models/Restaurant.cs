using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models
{
    public class Restaurant
    {
        public GeoCode geo { get; set; }
        public string hours { get; set; }
        public Address address { get; set; }
        public string restaurant_phone { get; set; }
        public int restaurant_id { get; set; }
        public string price_range { get; set; }
        public List<object> menus { get; set; }
        public int price_range_100 { get; set; }
        public List<string> cuisines { get; set; }
        public string restaurant_name { get; set; }
    }
}