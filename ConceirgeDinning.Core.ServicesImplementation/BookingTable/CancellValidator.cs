using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
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
        public bool CheckCancelTime(Booking booking)
        {
            DateTime currentDate = DateTime.Today;
            if (booking.Date < currentDate)
                return false;
            if (booking.Date == currentDate)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                int minutes = booking.Time.Minutes;
                int hours = booking.Time.Hours - currentTime.Hours;
                minutes += hours * 60;
                if (minutes < 240)
                    return false;
            }
            return true;
        }
    }
}
