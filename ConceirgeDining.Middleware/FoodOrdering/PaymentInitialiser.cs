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
        public int Start()
        {
            int orderId;
            orderId=paymentInitiator.AddEntryInOrderTable(orderResponse);
            paymentInitiator.AddEntriesInOrderDetailTable(orderId,orderResponse.MenuItems);
            return orderId;
        }
        
    }
}
