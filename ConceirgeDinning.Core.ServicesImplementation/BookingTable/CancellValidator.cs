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
            try
            {
                if (booking != null)
                    return true;
                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        public bool CheckCancellStatus(Booking booking)
        {
            try
            {
                if (booking.Status != "Cancelled")
                    return true;
                return false;
            }
            catch (Exception e )
            {

                throw e;
            }
            
        }
        public bool CheckCancelTime(Booking booking)
        {
            try
            {
                DateTime currentDate = DateTime.UtcNow;
                DateTime bookingDateTime = DateTime.Parse(booking.Utctime);
                var timeDifference = (bookingDateTime - currentDate).TotalMinutes;
                if (timeDifference <= 240 && booking.Status != "BookingInitiated")
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
