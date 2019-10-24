using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string SupplierName { get; set; }
        public string RestaurantAddress { get; set; }
        public string User_Rating { get; set; }
        public List<object> Cuisines { get; set; }
        public string ThumbURL { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
