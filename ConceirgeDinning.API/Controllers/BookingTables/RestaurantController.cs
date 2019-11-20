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

namespace ConceirgeDinning.API.Controllers.BookingTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(string locality, string latitude, string longitude)
        {
            RestaurantList restaurantList = new RestaurantList();
            if (locality is null)
                locality = string.Empty;
            Log.Information("request from user : locality -"+locality+" latitude-"+latitude+" longitude- "+longitude);
            var response = restaurantList.FetchRestarauntDetails(locality,latitude,longitude,"1");
            if (response == null)
            {
                Log.Information("response to user : 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            Log.Information("response to user: "+JsonConvert.SerializeObject(sortedresponse));
            return sortedresponse;

        }
    }
}