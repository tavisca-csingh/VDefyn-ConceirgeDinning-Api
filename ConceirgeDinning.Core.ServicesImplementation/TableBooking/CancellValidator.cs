using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.TableBooking
{
    public class CancellValidator
    {
        public bool CheckBookingId(Booking booking)
        {
            if (booking != null)
                return true;
            return false;
        }
        public bool CheckCancellStatus(Booking booking)
        {
            if (booking.Status != "Cancelled")
                return true;
            return false;
        }
    }
}
