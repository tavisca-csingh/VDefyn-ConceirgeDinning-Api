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
        public List<Restaurant> GetGeoCode(string locality)
        {
            BookingTable Fetch = new BookingTable();
            return Fetch.fetchRestarauntDetails(locality);
        }
    }
}