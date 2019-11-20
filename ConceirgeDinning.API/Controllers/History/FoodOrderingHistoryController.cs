using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.History;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConceirgeDinning.API.Controllers.History
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderingHistoryController : ControllerBase
    {
        // GET: api/FoodOrderingHistory
        [HttpGet]
        public FoodOrderingHistoryResponse Get(string userId,string corelationID)
        {
            OrderingHistory orderHistory = new OrderingHistory();
            return orderHistory.GetHistory(userId, corelationID);
            
        }

        // GET: api/FoodOrderingHistory/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FoodOrderingHistory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FoodOrderingHistory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
