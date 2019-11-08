using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDiningDAL.Models;

namespace ConceirgeDinning.ServicesImplementation.FoodOrdering
{
    public class PaymentInitiator
    {
        sql12310325Context conciergeContext = new sql12310325Context();
        public int AddEntryInOrderTable(OrderResponse orderResponse)
        {
            var restaurant = conciergeContext.RestaurantNames.Find(orderResponse.RestaurantId);
            if (restaurant == null)
            {
                //stores restaurent name
                RestaurantNames restaurantNames = new RestaurantNames();
                restaurantNames.RestaurantId = orderResponse.RestaurantId;
                restaurantNames.RestaurantName = orderResponse.RestaurantName;
                conciergeContext.RestaurantNames.Add(restaurantNames);
                conciergeContext.SaveChanges();
            }
            Ordering ordering = new Ordering();
            ordering.UserId = orderResponse.UserId;
            ordering.RestaurantId = orderResponse.RestaurantId;
            ordering.Status = "Order Placed";
            ordering.TotalPoints = orderResponse.TotalPoints;
            conciergeContext.Ordering.Add(ordering);
            conciergeContext.SaveChanges();
            return ordering.OrderId;
        }
        public void AddEntriesInOrderDetailTable(int orderId,List<Item> items)
        {
            
            foreach (var item in items)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = orderId;
                orderDetails.ItemName = item.name;
                orderDetails.Price = item.price;
                orderDetails.Quantity = item.quantity;
                conciergeContext.OrderDetails.Add(orderDetails);
            }
            conciergeContext.SaveChanges();
        }
    }
}
