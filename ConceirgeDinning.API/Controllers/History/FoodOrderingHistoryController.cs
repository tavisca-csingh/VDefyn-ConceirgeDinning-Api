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
    }
}
