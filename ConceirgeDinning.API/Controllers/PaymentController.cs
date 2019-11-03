using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.Middleware;
using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentResponse> StartPayment([FromBody]JObject jObject)
        {
            /* sql12310325Context sql12310325Context = new sql12310325Context();
             PaymentResponse paymentResponse = new PaymentResponse();
             int bookingId = Convert.ToInt32(jObject["bookingId"]);
             long pointBalance= Convert.ToInt64(jObject["pointBalance"]);
             string restaurntName=Convert.ToString(jObject["restaurantName"]);
             var booking = sql12310325Context.Booking.Find(bookingId);
             long requiredPoints = booking.Seats * booking.PointPricePerPerson;
             //-------------------------------------------------------------------------
             paymentResponse.Status = booking.Status;
             paymentResponse.BookingId = booking.BookingId;
             paymentResponse.RestaurantId = booking.RestaurantId;
             paymentResponse.UserName = booking.UserId;
             paymentResponse.Error = new List<string>();
             paymentResponse.NoOfGuests = booking.Seats;
             paymentResponse.PerPersonPoints = booking.PointPricePerPerson;
             paymentResponse.PointBalance = pointBalance - requiredPoints;
             paymentResponse.Date = booking.Date;
             paymentResponse.RestaurantName = restaurntName;
             paymentResponse.Time = booking.Time;
             paymentResponse.TotalPointPrice = requiredPoints;
             //------------------------------------------------------------------------------
             if (pointBalance>=requiredPoints)
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

                 booking.Status = "Booked";
                 sql12310325Context.SaveChanges();
             }
             else
             {
                 paymentResponse.Status = "booking failed";

                 paymentResponse.Error.Add("Insufficient Points");
             }


             return paymentResponse;*/
            int bookingId = Convert.ToInt32(jObject["bookingId"]);
            long pointBalance = Convert.ToInt64(jObject["pointBalance"]);
            string restaurantName = Convert.ToString(jObject["restaurantName"]);
            sql12310325Context sql12310325Context = new sql12310325Context(); 
            
            PaymentInitialisation paymentInitialisation = new PaymentInitialisation(bookingId);
            PaymentResponse paymentResponse = new PaymentResponse();
            paymentResponse=  paymentInitialisation.Validation(pointBalance);
            if(paymentResponse.Status== "Booking Possible")
                paymentResponse=paymentInitialisation.Start();
            paymentResponse.RestaurantName = restaurantName;
            return paymentResponse;
        }
        
        
    }
}