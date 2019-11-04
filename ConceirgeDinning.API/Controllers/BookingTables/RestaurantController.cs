using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;

namespace ConceirgeDinning.API.Controllers.BookingTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(string locality, string latitude, string longitude)
        {
<<<<<<< HEAD:ConceirgeDinning.API/Controllers/BookingTables/RestaurantController.cs
            RestaurantList restaurantList = new RestaurantList();
            if (locality is null)
                locality = string.Empty;
            var response = restaurantList.FetchRestarauntDetails(locality,latitude,longitude,"1");
=======
            RestaurantList Fetch = new RestaurantList();

            if (locality is null)
                locality = string.Empty;
            var response = Fetch.FetchRestarauntDetails(locality,latitude,longitude,"1");
>>>>>>> feature/CancellationApi:ConceirgeDinning.API/Controllers/BookingTable/RestaurantController.cs
            if (response == null)
                return Ok(StatusCodes.Status404NotFound);
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            return sortedresponse;

        }
    }
}