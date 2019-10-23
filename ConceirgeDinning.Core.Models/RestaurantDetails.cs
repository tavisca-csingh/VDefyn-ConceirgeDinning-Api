using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Core.Models
{
    public class RestaurantDetails
    {
        public string SupplierName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public string User_Rating { get; set; }
        public string Address { get; set; }
        public List<string> Cuisines { get; set; }
        public int PricePerHead { get; set; }
        public List<string> Images { get; set; }
    }
}
