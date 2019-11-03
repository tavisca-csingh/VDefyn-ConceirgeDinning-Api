using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class StartPayment
    {
        sql12310325Context sql12310325Context = new sql12310325Context();
        public void DeleteEntryInBookingProcess(int bookingId)
        {
            
            try
            {
                var query = sql12310325Context.BookingProgress
                       .Where(b => b.BookingId == bookingId)
                       .Last<BookingProgress>();
                sql12310325Context.BookingProgress.Remove(query);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void ChangeBookingStatus(Booking booking)
        {
            booking.Status = "Booked";
            sql12310325Context.Booking.Update(booking);
            sql12310325Context.SaveChanges();
        }
    }
}
