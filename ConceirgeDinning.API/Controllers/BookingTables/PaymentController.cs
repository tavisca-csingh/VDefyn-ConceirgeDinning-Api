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

namespace ConceirgeDinning.API.Controllers.BookingTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentResponse> StartPayment([FromBody]JObject jObject)
        {
            int bookingId = Convert.ToInt32(jObject["bookingId"]);
            long pointBalance = Convert.ToInt64(jObject["pointBalance"]);
            string restaurantName = Convert.ToString(jObject["restaurantName"]);
            sql12310325Context sql12310325Context = new sql12310325Context(); 
            
            PaymentInitialiser paymentInitialisation = new PaymentInitialiser(bookingId);
            PaymentResponse paymentResponse = new PaymentResponse();
            paymentResponse=  paymentInitialisation.Validation(pointBalance);
            if(paymentResponse.Status== "Booking Possible")
                paymentResponse=paymentInitialisation.Start();
            paymentResponse.RestaurantName = restaurantName;
            return paymentResponse;
        }
        
        
    }
}