using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class PaymentValidator
    {
        public bool CheckPointBalance(long pointBalance, long requiredPoints)
        {
            if (pointBalance >= requiredPoints)
            {
                return true;
            }
            return false;
        }
        public bool CheckBookingId(Booking booking)
        {
            if (booking !=null)
            {
                return true;
            }
            return false;
        }
    }
}
