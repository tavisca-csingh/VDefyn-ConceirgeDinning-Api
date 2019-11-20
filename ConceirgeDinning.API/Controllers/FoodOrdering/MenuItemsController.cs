using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ConceirgeDinning.API.Controllers.FoodOrdering
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Category>> GetMenuItems(string restaurantId, string supplierName)
        {
            MenuItemList menu = new MenuItemList();
            Log.Information("request from user: restaurantId- " + restaurantId + " supplierName- " + supplierName);
            var response = menu.GetMenus(restaurantId, supplierName);
            if (response == null)
            {
                Log.Information("response to user : 404");
                return NotFound(StatusCodes.Status404NotFound);
            }
            Log.Information("response sent to user: " + response);
            return response;
        }
    }
}