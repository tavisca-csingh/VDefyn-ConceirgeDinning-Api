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
            FoodOrderingHistoryResponse historyResponse = new FoodOrderingHistoryResponse();
            List<FoodOrderingHistory> foodOrderingHistory = new List<FoodOrderingHistory>();
            var response = from o in conceirgeContext.Ordering
                          join res in conceirgeContext.RestaurantNames on o.RestaurantId equals res.RestaurantId
                          join od in conceirgeContext.OrderDetails on o.OrderId equals od.OrderId
                          where o.UserId == userId
                          select new
                          {
                              orderId = o.OrderId,
                              date = o.TimeStamp.ToString(),
                              restaurantName = res.RestaurantName,
                              totalPoints = o.TotalPoints,
                              item = od.ItemName,
                              quanntity = od.Quantity,
                              price = od.Price

                          };


            historyResponse.IsDataAvailable = true;
            foreach (var item in response)
            {
                List<Item> menuItems = new List<Item>();
                if (!foodOrderingHistory.Exists(o => o.OrderId == item.orderId))
                {
                    foreach (var order in response)
                    {
                        if (item.orderId == order.orderId)
                        {
                            menuItems.Add(new Item()
                            {
                                Name = order.item,
                                Quantity = order.quanntity,
                                Price = order.price
                            });
                        }
                    }
                    foodOrderingHistory.Add(new FoodOrderingHistory()
                    {
                        OrderId = item.orderId,
                        Date = item.date.Split(' ')[0],
                        Time = getTime(item.date),
                        RestaurantName = item.restaurantName,
                        TotalPoints = item.totalPoints,
                        MenuItems = menuItems



                    });

                   
                }
            }
            if(foodOrderingHistory.Count==0)
            {
                historyResponse.IsDataAvailable = false;
            }
            historyResponse.Data = foodOrderingHistory.OrderByDescending(o=>o.Date).ThenByDescending(o=>o.Time).ToList();
            return historyResponse;
        }

        private string getTime(string timeString)
        {
            var token = timeString.Split(' ');
            return token[1] + " " +token[2];
           
        }
    }
}


                
          

      
     