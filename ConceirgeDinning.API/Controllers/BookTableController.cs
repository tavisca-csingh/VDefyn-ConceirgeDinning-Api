using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantForBookingTable.cs;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTableController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurant(string locality)
        {
            RestaurantForTableBooking restaurantForTableBooking = new RestaurantForTableBooking();
            if (restaurantForTableBooking.GetRestaurants(locality) == null)
               return Ok(StatusCodes.Status404NotFound);
            return restaurantForTableBooking.GetRestaurants(locality);
        }
    }
}