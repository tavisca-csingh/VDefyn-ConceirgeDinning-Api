using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class RestaurantAvailability
    {
        public string RestaurantId { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookedSeats { get; set; }

        public virtual RestaurantNames Restaurant { get; set; }
    }
}
