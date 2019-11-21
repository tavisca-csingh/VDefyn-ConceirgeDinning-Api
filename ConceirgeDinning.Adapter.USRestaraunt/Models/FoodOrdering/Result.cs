using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models.FoodOrdering
{
    public class Result
    {
        public int totalResults { get; set; }
        public List<Datum> data { get; set; }
        public int numResults { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public bool morePages { get; set; }
    }
}
