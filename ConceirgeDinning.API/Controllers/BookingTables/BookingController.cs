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
using Serilog;

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
            try
            {
                BookingInitialiser bookingInitialisation = new BookingInitialiser();
                BookingResponse bookingResponse = new BookingResponse();
                BookingRequest bookingRequest = JsonConvert.DeserializeObject<BookingRequest>(jObject.ToString());
                string UTCTime;
                bookingResponse = bookingInitialisation.Validate(bookingRequest, out UTCTime, appSettings);
                if (bookingResponse.Status == "BookingInitiated")
                {
                    bookingResponse = bookingInitialisation.Start(bookingRequest, UTCTime);

                }

                Log.Information("Status : Booking Initiated \nRequest from user : " + jObject + "\nResponse to User :" + JsonConvert.SerializeObject(bookingResponse));
                return bookingResponse;
            }
            catch (Exception e)
            {
                Log.Error("Status : Booking Initialisation Failed \nRequest from user : " + jObject + "\nResponse to User : null"+"\nError :" + e.Message);
                return Conflict();
            }
            
        }
    }
}