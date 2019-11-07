using System.Collections.Generic;

namespace ConceirgeDinning.Contracts.Models
{
   
    public class OrderResponse
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string UserId { get; set; }
        public long TotalPoints { get; set; }
        public List<Item> MenuItems { get; set; }
             
    }
    
}