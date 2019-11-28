using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.API.Controllers.FoodOrdering
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        public readonly IOptions<AppSettingsModel> appSettings;
        public MenuItemsController(IOptions<AppSettingsModel> app)
        {
            appSettings = app;
        }
        [HttpGet]
        public ActionResult<List<Category>> GetMenuItems(string restaurantId, string supplierName)
        {
            MenuItemList menu = new MenuItemList();
            var response = menu.GetMenus(restaurantId, supplierName,appSettings);
            if (response == null)
            {
                Log.Information("request from user: restaurantId- " + restaurantId + " supplierName- " + supplierName+" \n response to user : 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            Log.Information("request from user: restaurantId- " + restaurantId + " supplierName- " + supplierName+" \n response to user: " + JsonConvert.SerializeObject(response));
            return response;
        }
    }
}