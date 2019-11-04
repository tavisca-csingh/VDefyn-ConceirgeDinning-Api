using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware
{
    public class BookingInitialiser
    {
        public BookingResponse Validate(int noOfGuests, DateTime date,TimeSpan time, string restaurantId, string restaurantName, long perPersonPoints, long pointBalance)
        {
            BookingValidator bookingValidation = new BookingValidator();
            BookingResponse bookingResponse = new BookingResponse();
            bookingResponse.Error = new List<string>();
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

            else if(!bookingValidation.CheckTime(time)&&date==DateTime.Today)
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Can't book for past time");
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
            BookingInitiator startBooking = new BookingInitiator();
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
