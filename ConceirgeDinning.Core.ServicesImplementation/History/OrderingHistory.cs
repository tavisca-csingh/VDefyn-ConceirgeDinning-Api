using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.History
{
    public class OrderingHistory
    {
        private sql12310325Context conceirgeContext = new sql12310325Context();


        public FoodOrderingHistoryResponse GetHistory(string userId, string corelationId)
        {
            try
            {
                FoodOrderingHistoryResponse historyResponse = new FoodOrderingHistoryResponse();
                List<FoodOrderingHistory> foodOrderingHistories = new List<FoodOrderingHistory>();
                var response = (from o in conceirgeContext.Ordering
                                join res in conceirgeContext.RestaurantNames on o.RestaurantId equals res.RestaurantId
                                join od in conceirgeContext.OrderDetails on o.OrderId equals od.OrderId
                                where o.UserId == userId
                                select new
                                {
                                    orderId = o.OrderId,
                                    date = o.TimeStamp,
                                    restaurantName = o.Restaurant.RestaurantName,
                                    totalPoints = o.TotalPoints,

                                    orderDetails = o.OrderDetails

                                }).Distinct();


                historyResponse.IsDataAvailable = true;
                foreach (var item in response)
                {
                    FoodOrderingHistory foodOrderingHistory = new FoodOrderingHistory();
                    foodOrderingHistory.OrderId = item.orderId;
                    foodOrderingHistory.Date = item.date.ToString();
                    foodOrderingHistory.RestaurantName = item.restaurantName;
                    foodOrderingHistory.TotalPoints = item.totalPoints;
                    foodOrderingHistory.Time = item.date.ToString();
                    foodOrderingHistory.MenuItems = new List<Item>();
                    var enuItems = item.orderDetails.ToList();

                    foreach (var item1 in enuItems)
                    {
                        Item foodItem = new Item();
                        foodItem.Name = item1.ItemName;
                        foodItem.Price = item1.Price;
                        foodItem.Quantity = item1.Quantity;
                        foodOrderingHistory.MenuItems.Add(foodItem);
                    }



                    foodOrderingHistories.Add(foodOrderingHistory);
                }

                if (foodOrderingHistories.Count == 0)
                {
                    historyResponse.IsDataAvailable = false;
                }
                historyResponse.Data = foodOrderingHistories.OrderByDescending(o => o.Date).ThenByDescending(o => o.Date).ToList();
                return historyResponse;
            }
            catch (Exception e )
            {

                throw e;
            }
            
        }

        private string getTime(string timeString)
        {
            var token = timeString.Split(' ');
            return token[1] + " " + token[2];

        }
    }
}






