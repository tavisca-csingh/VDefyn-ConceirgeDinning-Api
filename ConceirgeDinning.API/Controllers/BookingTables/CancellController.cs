using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.Middleware;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ConceirgeDiningDAL.Models;
using ConceirgeDining.Middleware.BookingTable;
using Microsoft.Extensions.Options;
using Serilog;
using Newtonsoft.Json;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> _appsetting;
        public CancellController(IOptions<AppSettingsModel> app)
        {
            this._appsetting = app;
        }
        [HttpPost]
        public ActionResult<CancellResponse> StartPayment([FromBody]JObject jObject)
        {
            int bookingId = Convert.ToInt32(jObject["bookingId"]);
            long pointBalance = Convert.ToInt64(jObject["pointBalance"]);
            long totalPointPrice = Convert.ToInt64(jObject["totalPointPrice"]);

            sql12310325Context sql12310325Context = new sql12310325Context();
            Booking booking=null;
            try
            {
                booking = sql12310325Context.Booking.Find(bookingId);
                CancellInitialiser cancellInitialiser = new CancellInitialiser(booking);
                CancellResponse cancellResponse = new CancellResponse();
                cancellResponse = cancellInitialiser.Validation(bookingId, pointBalance);
                if (cancellResponse.Status == "Cancellation Possible")
                    cancellResponse = cancellInitialiser.Start(pointBalance, totalPointPrice);
                Log.Information("Status : Cancellation  \nRequest from user : " + jObject + "\nResponse to User :" + JsonConvert.SerializeObject(cancellResponse));
                return cancellResponse;
            }
            catch (Exception e)
            {

                Log.Error("Status : Cancellation Failed \nRequest from user : " + jObject + "\nResponse to User :  null" + "\nError :" + e.Message);
                return Conflict();
            }
            
        }
    }
}