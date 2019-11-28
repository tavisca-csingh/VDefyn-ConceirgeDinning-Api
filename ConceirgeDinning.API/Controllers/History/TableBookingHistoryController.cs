using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.History;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.API.Controllers.History
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableBookingHistoryController : Controller
    {
        [HttpGet]
        public ActionResult<TableBookingHistoryResponse> GetHistory(string userId,string corelationId)
        {
            try
            {
                BookingHistory bookingHistory = new BookingHistory();
                TableBookingHistoryResponse tableBookingHistoryResponse = new TableBookingHistoryResponse();
                tableBookingHistoryResponse = bookingHistory.GetBookingDetailsFromBookingTableByUserId(userId, corelationId);
                Log.Information("Status : Table Booking  History Result  \nRequest from user : { userId : " + userId + ",\ncorelationId :" + corelationId + " }" + "\nResponse to User : "+JsonConvert.SerializeObject(tableBookingHistoryResponse) );
                return tableBookingHistoryResponse;
            }
            catch (Exception e)
            {
                Log.Error("Status : Table Booking  History Error  \nRequest from user : { userId : " + userId + ",\ncorelationId :" + corelationId + " }" + "\nResponse to User : null" + "Error :" + e.Message );
                return Conflict();
            }
            
        }
    }
}