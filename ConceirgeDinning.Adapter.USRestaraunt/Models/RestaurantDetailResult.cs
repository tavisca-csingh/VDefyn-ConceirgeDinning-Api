using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models
{
    public class RestaurantDetailResult
    {
        public int totalResults { get; set; }
        public List<RestaurantDetails> data { get; set; }
        public int numResults { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public bool morePages { get; set; }
    }
}