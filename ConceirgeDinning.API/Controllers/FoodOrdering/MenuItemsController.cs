using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConceirgeDinning.API.Controllers.FoodOrdering
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MenuItem>> GetMenuItems(string restaurntId, string supplierName)
        {
            MenuItemList menu = new MenuItemList();
            var response = menu.GetMenus(restaurntId, supplierName);
            if (response is null)
                return NotFound(StatusCodes.Status404NotFound);
            return response;
        }
    }
}