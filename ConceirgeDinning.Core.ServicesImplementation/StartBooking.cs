using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class StartBooking
    {
        ConciergeContext conceirgeContext = new ConciergeContext();
        public int AddEntryInBookingTable(int noOfGuests, DateTime date, TimeSpan time, string restaurantId, string userName, string restaurantName, long perPersonPoints, long pointBalance)
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

            conceirgeContext.Booking.Add(booking);

            conceirgeContext.SaveChanges();
            conceirgeContext.Entry(booking).GetDatabaseValues();
            var query = conceirgeContext.Booking
                       .Where(b => b.Status == "BookingInitiated" && b.UserId == userName && b.RestaurantId == restaurantId && b.Time == time && b.Date == date)
                       .Last<Booking>();
           // conceirgeContext.Query;
            return query.BookingId;
        }
        public void UpdateSeats(string restaurantId,int noOfGuests, DateTime date)
        {
            RestaurantAvailability restaurantAvailability = new RestaurantAvailability();
            restaurantAvailability = conceirgeContext.RestaurantAvailability.Find(restaurantId,date);
            restaurantAvailability.BookedSeats += noOfGuests;
            conceirgeContext.SaveChanges();
            
        }
        public void AddEntryInProgressTable(int bookingId)
        {
            BookingProgress bookingProgress = new BookingProgress();
            bookingProgress.BookingId = bookingId;
            conceirgeContext.BookingProgress.Add(bookingProgress);
            conceirgeContext.SaveChanges();
        }
    }
}
