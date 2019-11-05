using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var response=restaurantDetailService.GetRestaurantDetails(restaurantId, supplierName);
            if (response == null)
                return NotFound(StatusCodes.Status404NotFound);
            return response;
            
        }
    }
}
