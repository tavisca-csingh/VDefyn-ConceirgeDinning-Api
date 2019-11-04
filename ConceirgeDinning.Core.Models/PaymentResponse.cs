using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class PaymentResponse
    {
        public string Status { get; set; }
        public List<string> Error { get; set; }
        public long TotalPointPrice { get; set; }
        public int BookingId { get; set; }
        public int NoOfGuests { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string RestaurantId { get; set; }
        public string UserName { get; set; }
        public string RestaurantName { get; set; }
        public long PerPersonPoints { get; set; }
        public long PointBalance { get; set; }
    }
}
