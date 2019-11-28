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
            try
            {
                if (pointBalance >= requiredPoints)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        public bool CheckBookingId(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e )
            {

                throw e;
            }
            
        }
    }
}
