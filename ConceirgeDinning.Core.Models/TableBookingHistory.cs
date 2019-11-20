using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class TableBookingHistory
    {
        public string Status { get; set; }
        public int BookingId { get; set; }
        public string RestaurantName { get; set; }
        public int NoOfGuests { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public long PerPersonPoints { get; set; }
        public bool IsCancellable { get; set; }
        public long FinalBill { get; set; }

    }
}
