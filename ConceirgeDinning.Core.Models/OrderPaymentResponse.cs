using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class OrderPaymentResponse
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public List<String> Error { get; set; }
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string UserId { get; set; }
        public long TotalPoints { get; set; }
        public List<Item> MenuItems { get; set; }
    }
}
