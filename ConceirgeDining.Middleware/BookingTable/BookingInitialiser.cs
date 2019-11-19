using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.BookingTable
{
    public class BookingInitialiser
    {
        public BookingResponse Validate(BookingRequest bookingRequest,out string UTCTime)
        {
            
            BookingValidator bookingValidation = new BookingValidator();
            BookingResponse bookingResponse = new BookingResponse();
            bookingResponse.Error = new List<string>();
            bookingResponse.BookingId = 0;
            bookingResponse.Status = "BookingInitiated";
            bookingResponse.TotalPointPrice = 0;

            if (!bookingValidation.CheckDateTime(bookingRequest.Date+"T"+bookingRequest.Time,bookingRequest.Latitude,bookingRequest.Longitude,out UTCTime))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Can't book for past dates");
            }
            
            if (!bookingValidation.CheckNoOfGuests(bookingRequest.NoOfGuests))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Guests should be atleast one and less than 15");
            }
            if (!bookingValidation.CheckPointAvailability(bookingRequest.NoOfGuests, bookingRequest.PerPersonPoints, bookingRequest.PointBalance))
            {
                bookingResponse.Status = "BookingNotInitiated";
                bookingResponse.Error.Add("Insufficient Points");
            }



            if (bookingResponse.Error.Count == 0)
            {
                int bookedSeats = bookingValidation.CheckAvailability(bookingRequest.NoOfGuests, DateTime.Parse(bookingRequest.Date), bookingRequest.RestaurantId, bookingRequest.RestaurantName);
                int availableSeats = 40 - bookedSeats;
                if (availableSeats < bookingRequest.NoOfGuests)
                {
                    bookingResponse.Status = "BookingNotInitiated";
                    if (availableSeats > 1)
                        bookingResponse.Error.Add("Only " + availableSeats + " are available at this restaurant");
                    else if (availableSeats == 1)
                        bookingResponse.Error.Add("Only " + availableSeats + " is available at this restaurant");
                    else
                        bookingResponse.Error.Add("Restaurant is totally booked");
                }
            }



            bookingResponse.NoOfGuests = bookingRequest.NoOfGuests;
            bookingResponse.Date = DateTime.Parse(bookingRequest.Date);
            bookingResponse.Time = TimeSpan.Parse(bookingRequest.Time);
            bookingResponse.RestaurantId = bookingRequest.RestaurantId;
            bookingResponse.UserName = bookingRequest.UserName;
            bookingResponse.RestaurantName = bookingRequest.RestaurantName;
            bookingResponse.PerPersonPoints = bookingRequest.PerPersonPoints;
            bookingResponse.PointBalance = bookingRequest.PointBalance;


            return bookingResponse;
        }
        public BookingResponse Start(BookingRequest bookingRequest,string UTCTime)
        {
            BookingInitiator startBooking = new BookingInitiator();
            BookingResponse bookingResponse = new BookingResponse();
            bookingResponse.Error = null;
            bookingResponse.Status = "BookingInitiated";
            int bookingId;
            bookingId = startBooking.AddEntryInBookingTable(bookingRequest.NoOfGuests, DateTime.Parse(bookingRequest.Date), TimeSpan.Parse(bookingRequest.Time), bookingRequest.RestaurantId, bookingRequest.RestaurantName, bookingRequest.UserName, bookingRequest.PerPersonPoints, bookingRequest.PointBalance, UTCTime);
            startBooking.UpdateSeats(bookingRequest.RestaurantId, bookingRequest.NoOfGuests, DateTime.Parse(bookingRequest.Date));
            startBooking.AddEntryInProgressTable(bookingId);
            bookingResponse.BookingId = bookingId;
            bookingResponse.TotalPointPrice = bookingRequest.NoOfGuests * bookingRequest.PerPersonPoints;
            bookingResponse.NoOfGuests = bookingRequest.NoOfGuests;
            bookingResponse.Date = DateTime.Parse(bookingRequest.Date);
            bookingResponse.Time = TimeSpan.Parse(bookingRequest.Time);
            bookingResponse.RestaurantId = bookingRequest.RestaurantId;
            bookingResponse.UserName = bookingRequest.UserName;
            bookingResponse.RestaurantName = bookingRequest.RestaurantName;
            bookingResponse.PerPersonPoints = bookingRequest.PerPersonPoints;
            bookingResponse.PointBalance = bookingRequest.PointBalance;
            return bookingResponse;
        }
    }
}
