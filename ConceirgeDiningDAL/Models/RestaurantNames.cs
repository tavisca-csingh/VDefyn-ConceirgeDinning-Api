using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class RestaurantNames
    {
        public RestaurantNames()
        {
            Booking = new HashSet<Booking>();
            RestaurantAvailability = new HashSet<RestaurantAvailability>();
        }

        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<RestaurantAvailability> RestaurantAvailability { get; set; }
    }
}
