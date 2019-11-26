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
using ConceirgeDining.Middleware.BookingTable;
using Microsoft.Extensions.Options;

namespace ConceirgeDinning.API.Controllers.BookingTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> appSettings;
        public BookingController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        [HttpPost]
        public ActionResult<BookingResponse> GetRestaurants([FromBody]JObject jObject)
        {
            BookingInitialiser bookingInitialisation = new BookingInitialiser();
            BookingResponse bookingResponse = new BookingResponse();
            BookingRequest bookingRequest= JsonConvert.DeserializeObject<BookingRequest>(jObject.ToString());
            string UTCTime;
            bookingResponse =bookingInitialisation.Validate(bookingRequest,out UTCTime,appSettings);
            if(bookingResponse.Status== "BookingInitiated")
            {
                bookingResponse=bookingInitialisation.Start(bookingRequest,UTCTime);

            }
            
            
            return bookingResponse;
        }
    }
}