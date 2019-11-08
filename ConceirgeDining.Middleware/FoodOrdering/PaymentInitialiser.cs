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
            int orderId;
            orderId=paymentInitiator.AddEntryInOrderTable(orderResponse);
            paymentInitiator.AddEntriesInOrderDetailTable(orderId,orderResponse.MenuItems);
            OrderPaymentResponse orderPaymentResponse = new OrderPaymentResponse();
            orderPaymentResponse.OrderId = orderId;
            orderPaymentResponse.RestaurantId = orderResponse.RestaurantId;
            orderPaymentResponse.RestaurantName = orderResponse.RestaurantName;
            orderPaymentResponse.UserId = orderResponse.UserId;
            orderPaymentResponse.TotalPoints = orderResponse.TotalPoints;
            orderPaymentResponse.MenuItems = orderResponse.MenuItems;
            orderPaymentResponse.OrderId = orderId;
            orderPaymentResponse.Error = null;
            orderPaymentResponse.Status = "Order Successful";


            return orderPaymentResponse;
        }
        
    }
}
