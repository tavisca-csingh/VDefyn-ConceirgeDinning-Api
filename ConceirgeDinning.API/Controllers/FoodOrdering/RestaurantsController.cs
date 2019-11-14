using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ConceirgeDinning.API.Controllers.FoodOrdering
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(string locality, string latitude, string longitude)
        {
            RestaurantList restaurantList = new RestaurantList();
            if (locality is null)
                locality = string.Empty;
            Log.Information("request from user : locality -" + locality + " latitude-" + latitude + " longitude- " + longitude);
            var response = restaurantList.FetchRestarauntDetails(locality, latitude, longitude,"2");
            if (response == null)
            {
                Log.Information("response to user : 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            Log.Information("response sent to user:" + sortedresponse);
            return sortedresponse;

        }
    }
}
