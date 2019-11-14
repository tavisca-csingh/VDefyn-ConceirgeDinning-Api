using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.BookingTable
{

    public class PaymentInitialiser
    {
        private Booking booking;
        PaymentResponse paymentResponse;
        sql12310325Context sql12310325Context = new sql12310325Context();
        public PaymentInitialiser(int bookingId)
        {
            this.booking = sql12310325Context.Booking.Find(bookingId); ;
            paymentResponse = new PaymentResponse();
            
            
        }
        
        public PaymentResponse Validation(long pointBalance)
        {
            PaymentValidator paymentValidation = new PaymentValidator();
            bool bookingIdStatus = paymentValidation.CheckBookingId(booking);
            if (!bookingIdStatus)
            {
                paymentResponse.Status = "Booking Failed";
                paymentResponse.Error = new List<string>();
                paymentResponse.Error.Add("Invalid Booking Id");
                paymentResponse.PointBalance = pointBalance;
                
                return paymentResponse;
            }
            long requiredPoints = booking.Seats * booking.PointPricePerPerson;
            bool pointStatus=paymentValidation.CheckPointBalance(pointBalance, requiredPoints);
            paymentResponse.Status = booking.Status;
            paymentResponse.BookingId = booking.BookingId;
            paymentResponse.RestaurantId = booking.RestaurantId;
            paymentResponse.UserName = booking.UserId;
            paymentResponse.Error = new List<string>();
            paymentResponse.NoOfGuests = booking.Seats;
            paymentResponse.PerPersonPoints = booking.PointPricePerPerson;
            paymentResponse.Date = booking.Date;
            
            paymentResponse.Time = booking.Time;
            
            
            if (!pointStatus)
            {
                paymentResponse.Status = "Booking Failed";

                paymentResponse.Error.Add("Insufficient Points");
                paymentResponse.PointBalance = pointBalance;
                paymentResponse.TotalPointPrice = booking.Seats * booking.PointPricePerPerson;

            }
            else
            {
                paymentResponse.Status = "Booking Possible";
            }
            return paymentResponse;

        }
        public PaymentResponse Start()
        {
            PaymentInitiator startPayment = new PaymentInitiator();
            paymentResponse.Status = booking.Status;
            paymentResponse.BookingId = booking.BookingId;
            paymentResponse.RestaurantId = booking.RestaurantId;
            paymentResponse.UserName = booking.UserId;
            paymentResponse.Error = new List<string>();
            paymentResponse.NoOfGuests = booking.Seats;
            paymentResponse.PerPersonPoints = booking.PointPricePerPerson;
            paymentResponse.Date = booking.Date;
            
            paymentResponse.Time = booking.Time;
            startPayment.DeleteEntryInBookingProcess(booking.BookingId);
            var status=startPayment.ChangeBookingStatus(booking);
            if (status)
            {
                paymentResponse.Status = "Booking Successful";
                paymentResponse.PointBalance = booking.LoyaltyPoints - booking.Seats * booking.PointPricePerPerson;
            }
                
            else
            {
                paymentResponse.Status = "Already Booked";
                paymentResponse.Error.Add("BookingId:" + booking.BookingId + " is already Booked");
            }
                
            
            paymentResponse.TotalPointPrice = booking.Seats * booking.PointPricePerPerson;
            return paymentResponse;
        }
    }
}
