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

namespace ConceirgeDinning.API.Controllers.BookingTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> appSettings;

        public RestaurantController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(string locality, string latitude, string longitude)
        {
            
            RestaurantList restaurantList = new RestaurantList();
            if (locality is null)
                locality = string.Empty;
            var response = restaurantList.FetchRestarauntDetails(locality,latitude,longitude,"1",appSettings);
            if (response == null)
            {
                Log.Information("request from user : locality -" + locality + " latitude-" + latitude + " longitude- " + longitude+"\n response to user : 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            Log.Information("request from user : locality -" + locality + " latitude-" + latitude + " longitude- " + longitude+" \n response to user: " +JsonConvert.SerializeObject(sortedresponse));
            return sortedresponse;

        }
    }
}