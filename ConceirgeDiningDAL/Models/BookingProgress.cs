using System;
using System.Collections.Generic;

namespace ConceirgeDiningDAL.Models
{
    public partial class BookingProgress
    {
        public int BookingProgreeId { get; set; }
        public int BookingId { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
