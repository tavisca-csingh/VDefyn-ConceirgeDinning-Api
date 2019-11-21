using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class FoodOrderingHistoryResponse
    {
        public bool IsDataAvailable { get; set; }
        public List<FoodOrderingHistory> Data { get; set; }
    }
}
