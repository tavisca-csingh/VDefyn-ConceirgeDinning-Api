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
            tableBookingHistoryResponse.bookingHistories= (bookingHistory.GetBookingDetailsFromBookingTableByUserId(userId, corelationId)).OrderByDescending(o=>o.Date).ThenBy(o=>o.Time).ToList();
            if (tableBookingHistoryResponse.bookingHistories.Count > 0)
                tableBookingHistoryResponse.IsDataAvailable = true;
            else
                tableBookingHistoryResponse.IsDataAvailable = false;
            return tableBookingHistoryResponse;
        }
    }
}