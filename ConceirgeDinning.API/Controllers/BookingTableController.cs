using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.Core.ServicesImplementation;
using ConceirgeDinning.Core.Models;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTableController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Restaurant>> GetGeoCode(string locality)
        {
            BookingTable Fetch = new BookingTable();
            var response= Fetch.fetchRestarauntDetails(locality);
            if (response == null)
                return Ok(StatusCodes.Status404NotFound);
            return response;
        }
    }
}