using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.ServicesImplementation;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDining.Middleware;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<BookingResponse> GetRestaurants(int noOfGuests, DateTime date, TimeSpan time,string restaurantId,string userName,string restaurantName,long perPersonPoints,long pointBalance)
        {
            BookingInitialiser bookingInitialisation = new BookingInitialiser();
            BookingResponse bookingResponse = new BookingResponse();
            
            bookingResponse=bookingInitialisation.Validate(noOfGuests, date,time, restaurantId,  restaurantName,  perPersonPoints,  pointBalance);
            if(bookingResponse.Status== "BookingInitiated")
            {
                bookingResponse=bookingInitialisation.Start(noOfGuests, date, time, restaurantId, restaurantName, userName, perPersonPoints, pointBalance);

            }
            if (true)
            {
                bookingResponse.NoOfGuests = noOfGuests;
                bookingResponse.Date = date;
                bookingResponse.Time = time;
                bookingResponse.RestaurantId = restaurantId;
                bookingResponse.UserName = userName;
                bookingResponse.RestaurantName = restaurantName;
                bookingResponse.PerPersonPoints = perPersonPoints;
                bookingResponse.PointBalance = pointBalance;
            }

            return bookingResponse;
        }
    }
}