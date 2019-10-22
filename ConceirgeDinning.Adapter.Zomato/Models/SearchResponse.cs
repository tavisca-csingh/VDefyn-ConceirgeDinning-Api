using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Models
{
    class SearchResponse
    {
        public int results_found { get; set; }
        public int results_start { get; set; }
        public int results_shown { get; set; }
        public Restaurant[] restaurants { get; set; }
    }
}
