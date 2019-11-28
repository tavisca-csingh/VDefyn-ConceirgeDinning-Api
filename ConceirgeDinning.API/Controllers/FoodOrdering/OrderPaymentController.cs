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
using Serilog;

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
                Log.Information("Status : Food Payment Done  \nRequest from user : " + jsonData + "Response to User :" + JsonConvert.SerializeObject(orderPaymentResponse));

            }
            catch (Exception e)
            {

                orderPaymentResponse.Status = "Order Failed";
                orderPaymentResponse.Error = new List<string>();
                orderPaymentResponse.Error.Add("Server Error Contact Admin");
                Log.Error("Status : Food Payment Error  \nRequest from user : " + jsonData + "\nResponse to User :" + JsonConvert.SerializeObject(orderPaymentResponse)+"\nError : "+e.Message);
               
            }

            return orderPaymentResponse;
        }
    }
}