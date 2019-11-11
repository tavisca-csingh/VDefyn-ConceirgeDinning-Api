using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.ServicesImplementation;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDining.Middleware;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ConceirgeDinning.API.Controllers.BookingTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost]
        public ActionResult<BookingResponse> GetRestaurants([FromBody]JObject jObject)
        {
            BookingInitialiser bookingInitialisation = new BookingInitialiser();
            BookingResponse bookingResponse = new BookingResponse();
            BookingRequest bookingRequest= JsonConvert.DeserializeObject<BookingRequest>(jObject.ToString());

            bookingResponse =bookingInitialisation.Validate(bookingRequest);
            if(bookingResponse.Status== "BookingInitiated")
            {
                bookingResponse=bookingInitialisation.Start(bookingRequest);

            }
            
            
            return bookingResponse;
        }
    }
}