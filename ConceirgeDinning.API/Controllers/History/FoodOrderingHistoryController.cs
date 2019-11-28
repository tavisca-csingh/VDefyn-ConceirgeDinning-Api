using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.History;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.API.Controllers.History
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderingHistoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<FoodOrderingHistoryResponse> Get(string userId,string corelationID)
        {
            try
            {
                OrderingHistory orderHistory = new OrderingHistory();
                FoodOrderingHistoryResponse foodOrderingHistoryResponse= orderHistory.GetHistory(userId, corelationID);
                Log.Information("Status : Food Order history  result  \nRequest from user : { userId : " + userId +",\ncorelationId :" +corelationID+" }" + "\nResponse to User :" + JsonConvert.SerializeObject(foodOrderingHistoryResponse) );
                return foodOrderingHistoryResponse;
            }
            catch (Exception e)
            {
                Log.Error("Status : Food Order history Error  \nRequest from user : { userId : " + userId + ",\ncorelationId :" + corelationID + " }" + "\nResponse to User : null" + "\nError : " + e.Message);
                return Conflict();
            }
            


        }


    }
}
