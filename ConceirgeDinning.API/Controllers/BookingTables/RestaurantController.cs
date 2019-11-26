using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.Core.ServicesImplementation;
using Serilog;
using Newtonsoft.Json;
using ConceirgeDinning.Contracts.Models;
using Microsoft.Extensions.Options;
using ConceirgeDining.LoggerDAL.Models;
using System.Diagnostics;

namespace ConceirgeDinning.API.Controllers.BookingTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> _appSettings;

        public RestaurantController(IOptions<AppSettingsModel> appsettings)
        {
            _appSettings = appsettings;
        }
        
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(LogInfo logInfo,string locality, string latitude, string longitude)
        {
            
            RestaurantList restaurantList = new RestaurantList();
            logInfo.SessionId = Guid.NewGuid().ToString();
            logInfo.TimeStamp = DateTime.UtcNow;
            logInfo.Request = locality + "," + latitude + "," + longitude;

            if (locality is null)
                locality = string.Empty;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            var response = restaurantList.FetchRestarauntDetails(locality,latitude,longitude,"1",_appSettings);
            timer.Stop();
            logInfo.ResponseTime = timer.Elapsed;

            logInfo.Response = JsonConvert.SerializeObject(response);
            logInfo.Status = "Success";

            if (response == null)
            {
                logInfo.Status = "Failure";
                return NotFound(StatusCodes.Status404NotFound);
            }

            logInfo.Supplier = "V-Defyn";
            
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            
            return sortedresponse;

        }
    }
}