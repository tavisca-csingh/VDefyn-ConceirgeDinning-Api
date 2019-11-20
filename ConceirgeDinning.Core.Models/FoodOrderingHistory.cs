using System;
using System.Collections.Generic;

namespace ConceirgeDinning.Contracts.Models
{
    public class FoodOrderingHistory
    {
        public int  OrderId{ get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string RestaurantName { get; set; }
        public List<Item> MenuItems { get; set; }
        public long TotalPoints { get; set; }

    }
}