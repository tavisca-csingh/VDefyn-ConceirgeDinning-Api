using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Core.Models
{
    public class Restaurant

    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string SupplierName { get; set; }
        public string LocalityVerbose { get; set; }
        public string User_Rating { get; set; }
        public List<String> Cuisines { get; set; }
        public string ThumbURL { get; set; }
    }
}
