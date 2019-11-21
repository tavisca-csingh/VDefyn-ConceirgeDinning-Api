using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.History;
using Microsoft.AspNetCore.Mvc;

namespace ConceirgeDinning.API.Controllers.History
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableBookingHistoryController : Controller
    {
        [HttpGet]
        public ActionResult<TableBookingHistoryResponse> GetHistory(string userId,string corelationId)
        {
            BookingHistory bookingHistory = new BookingHistory();
            TableBookingHistoryResponse tableBookingHistoryResponse = new TableBookingHistoryResponse();
            tableBookingHistoryResponse= bookingHistory.GetBookingDetailsFromBookingTableByUserId(userId, corelationId);
            
            return tableBookingHistoryResponse;
        }
    }
}