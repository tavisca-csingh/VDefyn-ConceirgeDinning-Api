using System;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.Middleware.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConceirgeDinning.API.Controllers.FoodOrdering
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class OrderPaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<OrderResponse> payment([FromBody]JObject jsonData)
        {
            OrderResponse orderResponse;
            try
            {
                orderResponse = JsonConvert.DeserializeObject<OrderResponse>(jsonData.ToString());
                PaymentInitialiser paymentInitialiser = new PaymentInitialiser(orderResponse);
                paymentInitialiser.Start();
            }
            catch (Exception e)
            {

                throw;
            }   
            
            return orderResponse;
        }
    }
}