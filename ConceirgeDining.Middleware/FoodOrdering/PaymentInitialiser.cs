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
        OrderPaymentRequest orderPaymentRequest;
        PaymentInitiator paymentInitiator;
        public PaymentInitialiser(OrderPaymentRequest orderPaymentRequest)
        {
            this.orderPaymentRequest = orderPaymentRequest;
            paymentInitiator = new PaymentInitiator();
        }
        public OrderPaymentResponse Start()
        {
            Ordering ordering;
            ordering = paymentInitiator.AddEntryInOrderTable(orderPaymentRequest);
            paymentInitiator.AddEntriesInOrderDetailTable(ordering.OrderId, orderPaymentRequest.MenuItems);
            OrderPaymentResponse orderPaymentResponse = new OrderPaymentResponse();
            orderPaymentResponse.OrderId = ordering.OrderId;
            orderPaymentResponse.RestaurantId = orderPaymentRequest.RestaurantId;
            orderPaymentResponse.RestaurantName = orderPaymentRequest.RestaurantName;
            orderPaymentResponse.UserId = orderPaymentRequest.UserId;
            orderPaymentResponse.TotalPoints = orderPaymentRequest.TotalPoints;
            orderPaymentResponse.MenuItems = orderPaymentRequest.MenuItems;
            orderPaymentResponse.Error = null;
            orderPaymentResponse.Status = "Order Successful";
            orderPaymentResponse.date = ordering.TimeStamp;

            return orderPaymentResponse;
        }
        
    }
}
