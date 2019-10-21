using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConceirgeDinning.Core.ServicesImplementation;

namespace ConceirgeDinning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTableController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetGeoCode(string locality)
        {
            BookingTable findLatLong = new BookingTable();
            return findLatLong.FetchLAt(locality).Latitude == 0.00 ? new string[] { "false" } : new string[] { "true" };
        }
    }
}