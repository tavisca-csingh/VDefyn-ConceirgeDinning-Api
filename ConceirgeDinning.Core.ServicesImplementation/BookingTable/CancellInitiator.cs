using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class CancellInitiator
    {
        sql12310325Context sql12310325Context = new sql12310325Context();
        Booking booking;
        public CancellInitiator(Booking booking)
        {
            this.booking = booking;
        }
        public void DeleteEntryInBookingProcess()
        {
            try
            {
                var query = sql12310325Context.BookingProgress
                       .Where(b => b.BookingId == booking.BookingId)
                       .Last<BookingProgress>();
                if (query != null)
                    sql12310325Context.BookingProgress.Remove(query);
                sql12310325Context.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void ChangeBookingStatus()
        {
            
            booking.Status = "Cancelled";
            sql12310325Context.Booking.Update(booking);
            sql12310325Context.SaveChanges();
            
        }
        public void ChangeSeatsStatus()
        {
            string restauranId = booking.RestaurantId;
            try
            {
                RestaurantAvailability restaurantAvailability = sql12310325Context.RestaurantAvailability.Find(restauranId,booking.Date);
                restaurantAvailability.BookedSeats -= booking.Seats;
                sql12310325Context.RestaurantAvailability.Update(restaurantAvailability);
                sql12310325Context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
