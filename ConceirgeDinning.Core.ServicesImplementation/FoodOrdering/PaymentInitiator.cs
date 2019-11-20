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
        public Ordering AddEntryInOrderTable(OrderPaymentRequest orderPaymentRequest)
        {
            var restaurant = conciergeContext.RestaurantNames.Find(orderPaymentRequest.RestaurantId);
            if (restaurant == null)
            {
                //stores restaurent name
                RestaurantNames restaurantNames = new RestaurantNames();
                restaurantNames.RestaurantId = orderPaymentRequest.RestaurantId;
                restaurantNames.RestaurantName = orderPaymentRequest.RestaurantName;
                conciergeContext.RestaurantNames.Add(restaurantNames);
                conciergeContext.SaveChanges();
            }
            Ordering ordering = new Ordering();
            ordering.UserId = orderPaymentRequest.UserId;
            ordering.RestaurantId = orderPaymentRequest.RestaurantId;
            ordering.Status = "Order Placed";
            ordering.TotalPoints = orderPaymentRequest.TotalPoints;
            ordering.TimeStamp = DateTime.Parse(orderPaymentRequest.DateTime);
            conciergeContext.Ordering.Add(ordering);
            conciergeContext.SaveChanges();
            return ordering;
        }
        public void AddEntriesInOrderDetailTable(int orderId,List<Item> items)
        {
            
            foreach (var item in items)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = orderId;
                orderDetails.ItemName = item.Name;
                orderDetails.Price = item.Price;
                orderDetails.Quantity = item.Quantity;

                conciergeContext.OrderDetails.Add(orderDetails);
            }
            conciergeContext.SaveChanges();
        }
    }
}
