using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class BookingRequest
    {
        public int NoOfGuests { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string RestaurantId { get; set; }
        public string UserName { get; set; }
        public string RestaurantName { get; set; }
        public long PerPersonPoints { get; set; }
        public long PointBalance { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
