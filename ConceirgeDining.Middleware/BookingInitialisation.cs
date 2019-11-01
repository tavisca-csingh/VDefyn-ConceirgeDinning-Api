using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware
{
    public class BookingInitialisation
    {
        public BookingResponse Validate(int noOfGuests, DateTime date, string restaurantId, string restaurantName, long perPersonPoints, long pointBalance)
        {
            BookingValidation bookingValidation = new BookingValidation();
            BookingResponse bookingResponse = new BookingResponse();
            bookingResponse.BookingId = 0;
            bookingResponse.Status = "BookingInitiated";
            bookingResponse.TotalPointPrice = 0;
            if(!bookingValidation.CheckAvailability(noOfGuests, date, restaurantId, restaurantName))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Seats are not available");
            }
            if (!bookingValidation.CheckNoOfGuests(noOfGuests))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Guests should be atleast one and less than 15");
            }
            if (!bookingValidation.CheckDate(date))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Can't book for past dates");
            }
            if (!bookingValidation.CheckPointAvailability(noOfGuests, perPersonPoints, pointBalance))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Insufficient Points");
            }
            
            
            
            return bookingResponse;
        }
        public BookingResponse Start(int noOfGuests, DateTime date, TimeSpan time, string restaurantId, string userName, string restaurantName, long perPersonPoints, long pointBalance)
        {
            StartBooking startBooking = new StartBooking();
            BookingResponse bookingResponse = new BookingResponse();
            bookingResponse.Error = null;
            bookingResponse.Status = "BookingInitiated";
            int bookingId;
            bookingId=startBooking.AddEntryInBookingTable(noOfGuests, date,time, restaurantId, restaurantName, userName,perPersonPoints, pointBalance);
            startBooking.UpdateSeats(restaurantId,noOfGuests,date);
            startBooking.AddEntryInProgressTable(bookingId);
            bookingResponse.BookingId = bookingId;
            bookingResponse.TotalPointPrice = noOfGuests * perPersonPoints;
            return bookingResponse;
        }
    }
}
