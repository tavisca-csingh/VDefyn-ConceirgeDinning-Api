using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.Core.ServicesImplementation;
using ConceirgeDinning.Core.Models;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Restaurant>> GetRestaurants(string locality, string latitude, string longitude)
        {
            RestaurantList Fetch = new RestaurantList();
            if (locality is null)
                locality = string.Empty;
            var response = Fetch.fetchRestarauntDetails(locality,latitude,longitude);
            if (response == null)
                return Ok(StatusCodes.Status404NotFound);
            List<Restaurant> sortedresponse = response.OrderByDescending(o => o.User_Rating).ToList();
            return sortedresponse;

        }


    }
}