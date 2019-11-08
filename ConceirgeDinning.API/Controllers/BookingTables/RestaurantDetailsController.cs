using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailsController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult<RestaurantDetails> GetRestaurantDetails(int restaurantId,string supplierName)
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            Log.Information("request from user: restaurantId- " + restaurantId + " supplierName- " + supplierName);
            var response=restaurantDetailService.GetRestaurantDetails(restaurantId, supplierName);
            if (response == null)
            {
                Log.Information("response to user: 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            Log.Information("response to user: " + response);
            return response;
            
        }
    }
}
