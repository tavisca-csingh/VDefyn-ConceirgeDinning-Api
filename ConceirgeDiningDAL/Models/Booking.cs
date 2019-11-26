using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingProgress = new HashSet<BookingProgress>();
        }

        public int BookingId { get; set; }
        public string RestaurantId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public int Seats { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public long LoyaltyPoints { get; set; }
        public long PointPricePerPerson { get; set; }
        public string Utctime { get; set; }

        public virtual RestaurantNames Restaurant { get; set; }
        public virtual ICollection<BookingProgress> BookingProgress { get; set; }
    }
}
