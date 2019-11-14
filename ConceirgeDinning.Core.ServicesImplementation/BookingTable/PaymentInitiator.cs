using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class PaymentInitiator
    {
        sql12310325Context sql12310325Context = new sql12310325Context();
        public void DeleteEntryInBookingProcess(int bookingId)
        {
            
            try
            {
                var query = sql12310325Context.BookingProgress
                       .Where(b => b.BookingId == bookingId)
                       .Last<BookingProgress>();
                if(query!=null)
                    sql12310325Context.BookingProgress.Remove(query);

            }
            catch (Exception e)
            {

                
            }
        }
        public bool ChangeBookingStatus(Booking booking)
        {
            if (booking.Status == "Booked")
                return false;
            booking.Status = "Booked";
            sql12310325Context.Booking.Update(booking);
            sql12310325Context.SaveChanges();
            return true;
        }
    }
}
