using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class BookingInitiator
    {
        sql12310325Context sql12310325Context = new sql12310325Context();
        public int AddEntryInBookingTable(int noOfGuests, DateTime date, TimeSpan time, string restaurantId, string userName, string restaurantName, long perPersonPoints, long pointBalance,string UTCTime)
        {
            Booking booking = new Booking();
            booking.Status = "BookingInitiated";
            booking.RestaurantId = restaurantId;
            booking.UserId = userName;
            booking.Seats = noOfGuests;
            booking.Date = date;
            booking.Time = time;
            booking.LoyaltyPoints = pointBalance;
            booking.PointPricePerPerson = perPersonPoints;
            booking.Utctime = UTCTime;

            sql12310325Context.Booking.Add(booking);

            sql12310325Context.SaveChanges();
            sql12310325Context.Entry(booking).GetDatabaseValues();
            var query = sql12310325Context.Booking
                       .Where(b => b.Status == "BookingInitiated" && b.UserId == userName && b.RestaurantId == restaurantId && b.Time == time && b.Date == date)
                       .Last<Booking>();
           // sql12310325Context.Query;
            return query.BookingId;
        }
        public void UpdateSeats(string restaurantId,int noOfGuests, DateTime date)
        {
            RestaurantAvailability restaurantAvailability = new RestaurantAvailability();
            restaurantAvailability = sql12310325Context.RestaurantAvailability.Find(restaurantId,date);
            restaurantAvailability.BookedSeats += noOfGuests;
            sql12310325Context.SaveChanges();
            
        }
        public void AddEntryInProgressTable(int bookingId)
        {
            BookingProgress bookingProgress = new BookingProgress();
            bookingProgress.BookingId = bookingId;
            bookingProgress.TimeStamp = DateTime.UtcNow;
            sql12310325Context.BookingProgress.Add(bookingProgress);
            sql12310325Context.SaveChanges();
        }
    }
}