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
        public ActionResult<OrderPaymentResponse> payment([FromBody]JObject jsonData)
        {
            OrderResponse orderResponse;
            OrderPaymentResponse orderPaymentResponse = new OrderPaymentResponse();
            try
            {
                int orderId;
                orderResponse = JsonConvert.DeserializeObject<OrderResponse>(jsonData.ToString());
                PaymentInitialiser paymentInitialiser = new PaymentInitialiser(orderResponse);
                orderId=paymentInitialiser.Start();
                orderPaymentResponse.RestaurantId = orderResponse.RestaurantId;
                orderPaymentResponse.RestaurantName = orderResponse.RestaurantName;
                orderPaymentResponse.UserId = orderResponse.UserId;
                orderPaymentResponse.TotalPoints = orderResponse.TotalPoints;
                orderPaymentResponse.MenuItems = orderResponse.MenuItems;
                orderPaymentResponse.OrderId = orderId;
            }
            catch (Exception e)
            {

                throw;
            }   
            
            return orderPaymentResponse;
        }
    }
}