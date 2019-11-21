using ConceirgeDiningDAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConceirgeDinning.Contracts.Models;

namespace ConceirgeDinning.ServicesImplementation.History
{
    public class BookingHistory
    {
        public bool CheckCancelTime(string utcTime,string status)
        {
            DateTime currentDate = DateTime.UtcNow;
            DateTime bookingDateTime = DateTime.Parse(utcTime);
            var timeDifference = (bookingDateTime - currentDate).TotalMinutes;
            if (timeDifference <= 240 && status != "BookingInitiated")
            {
                return false;
            }
            return true;
        }
        public TableBookingHistoryResponse GetBookingDetailsFromBookingTableByUserId(string userId, string corelationId)
        {
            TableBookingHistoryResponse tableBookingHistoryResponse = new TableBookingHistoryResponse();
            tableBookingHistoryResponse.bookingHistories = new List<TableBookingHistory>();
            sql12310325Context conciergeContext = new sql12310325Context();
            var bookingResults = from b in conciergeContext.Booking
                                 join rn in conciergeContext.RestaurantNames
                                 on b.RestaurantId equals rn.RestaurantId
                                 where b.UserId == userId & b.Status != "BookingInitiated"
                                 select new {
                                     status = b.Status,
                                     bookingId = b.BookingId,
                                     restaurantName = rn.RestaurantName,
                                     noOfGuests = b.Seats,
                                     date = b.Date,
                                     time = b.Time,
                                     PointPerPerson = b.PointPricePerPerson,
                                     utcTime = b.Utctime
                                 };
            foreach(var item in bookingResults)
            {
                TableBookingHistory tableBookingHistory = new TableBookingHistory();
                tableBookingHistory.Status = item.status;
                tableBookingHistory.BookingId = item.bookingId;
                tableBookingHistory.RestaurantName = item.restaurantName;
                tableBookingHistory.NoOfGuests = item.noOfGuests;
                tableBookingHistory.Date = item.date;
                tableBookingHistory.Time = item.time;
                tableBookingHistory.PerPersonPoints = item.PointPerPerson;
                tableBookingHistory.FinalBill = item.noOfGuests * item.PointPerPerson;
                tableBookingHistory.IsCancellable = CheckCancelTime(item.utcTime,item.status);
                tableBookingHistoryResponse.bookingHistories.Add(tableBookingHistory);

            }
            tableBookingHistoryResponse.bookingHistories=tableBookingHistoryResponse.bookingHistories.OrderByDescending(o => o.Date).ThenByDescending(o => o.Time).ToList();
            if (tableBookingHistoryResponse.bookingHistories.Count > 0)
                tableBookingHistoryResponse.IsDataAvailable = true;
            else
                tableBookingHistoryResponse.IsDataAvailable = false;
            return tableBookingHistoryResponse;
        }
    }
}
