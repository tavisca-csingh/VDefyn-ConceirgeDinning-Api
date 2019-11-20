using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class TableBookingHistoryResponse
    {
        public bool IsDataAvailable { get; set; }
        public List<TableBookingHistory> bookingHistories { get; set; }
    }
}
