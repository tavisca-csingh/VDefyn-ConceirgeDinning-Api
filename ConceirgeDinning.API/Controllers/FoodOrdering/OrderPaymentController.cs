using System;
using System.Collections.Generic;
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
        public ActionResult<OrderPaymentResponse> payment([FromBody]JObject jsonData)
        {
            OrderPaymentRequest orderPaymentRequest;
            OrderPaymentResponse orderPaymentResponse = new OrderPaymentResponse();
            try
            {
                
                orderPaymentRequest = JsonConvert.DeserializeObject<OrderPaymentRequest>(jsonData.ToString());
                PaymentInitialiser paymentInitialiser = new PaymentInitialiser(orderPaymentRequest);
                orderPaymentResponse=paymentInitialiser.Start();
                
            }
            catch (Exception e)
            {

                orderPaymentResponse.Status = "Order Failed";
                orderPaymentResponse.Error = new List<string>();
                orderPaymentResponse.Error.Add("Server Error Contact Admin");
            }   
            
            return orderPaymentResponse;
        }
    }
}