using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailsController : ControllerBase
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        public RestaurantDetailsController(IOptions<AppSettingsModel> app)
        {
            this._appSettings = app;
        }
        [HttpGet]
        public ActionResult<RestaurantDetails> GetRestaurantDetails(int restaurantId, string supplierName)
        {
            RestaurantDetailService restaurantDetailService = new RestaurantDetailService();
            Log.Information("request from user: restaurantId- " + restaurantId + " supplierName- " + supplierName);
            var response = restaurantDetailService.GetRestaurantDetails(restaurantId, supplierName, _appSettings);
            if (response == null)
            {
                Log.Information("response to user: 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            Log.Information("response to user: " + JsonConvert.SerializeObject(response));
            return response;

        }
    }
}
