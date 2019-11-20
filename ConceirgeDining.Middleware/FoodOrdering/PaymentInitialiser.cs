using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.FoodOrdering
{
    public class PaymentInitialiser
    {
        OrderResponse orderResponse;
        PaymentInitiator paymentInitiator;
        public PaymentInitialiser(OrderResponse orderResponse)
        {
            this.orderResponse = orderResponse;
            paymentInitiator = new PaymentInitiator();
        }
        public OrderPaymentResponse Start()
        {
            Ordering ordering;
            ordering = paymentInitiator.AddEntryInOrderTable(orderResponse);
            paymentInitiator.AddEntriesInOrderDetailTable(ordering.OrderId, orderResponse.MenuItems);
            OrderPaymentResponse orderPaymentResponse = new OrderPaymentResponse();
            orderPaymentResponse.OrderId = ordering.OrderId;
            orderPaymentResponse.RestaurantId = orderResponse.RestaurantId;
            orderPaymentResponse.RestaurantName = orderResponse.RestaurantName;
            orderPaymentResponse.UserId = orderResponse.UserId;
            orderPaymentResponse.TotalPoints = orderResponse.TotalPoints;
            orderPaymentResponse.MenuItems = orderResponse.MenuItems;
            orderPaymentResponse.Error = null;
            orderPaymentResponse.Status = "Order Successful";
            orderPaymentResponse.date = ordering.TimeStamp;

            return orderPaymentResponse;
        }
        
    }
}
