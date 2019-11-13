﻿using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ConceirgeDiningDAL.Models;

namespace ConceirgeDinning.ServicesImplementation.FoodOrdering
{
    public class PaymentInitiator
    {
        sql12310325Context conciergeContext = new sql12310325Context();
        public Ordering AddEntryInOrderTable(OrderResponse orderResponse)
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
            ordering.TimeStamp = DateTime.Now;
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
