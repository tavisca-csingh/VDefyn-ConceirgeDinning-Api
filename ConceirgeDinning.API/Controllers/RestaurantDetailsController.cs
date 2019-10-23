using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Core.ServicesImplementation;
using Microsoft.AspNetCore.Mvc;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<RestaurantDetails> GetRestaurantDetails(int restaurantId,string supplierName)
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            return restaurantDetailService.GetRestaurantDetails(restaurantId, supplierName);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
