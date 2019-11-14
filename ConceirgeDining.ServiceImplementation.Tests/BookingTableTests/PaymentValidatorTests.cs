using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConceirgeDinning.ServicesImplementation;
using ConceirgeDinning.ServicesImplementation.BookingTable;

namespace ConceirgeDining.ServiceImplementation.Tests.BookingTableTests
{
    public class PaymentValidatorTests
    {
        Booking booking = new Booking();
        PaymentValidator paymentValidator = new PaymentValidator();

        [Fact]
        public void Check_For_Valid_Booking_Id()
        {
            bool actual = paymentValidator.CheckBookingId(booking);
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Invalid_Booking_Id()
        {
            bool actual = paymentValidator.CheckBookingId(null);
            Assert.False(actual);
        }

        [Fact]
        public void Check_For_Sufficient_Point_Balance()
        {
            long availablePointBalance = 10000;
            long requiredPointBalance = 1000;
            bool actual = paymentValidator.CheckPointBalance(availablePointBalance,requiredPointBalance);
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Insufficient_Point_Balance()
        {
            long availablePointBalance = 1000;
            long requiredPointBalance = 10000;
            bool actual = paymentValidator.CheckPointBalance(availablePointBalance, requiredPointBalance);
            Assert.False(actual);
        }
    }
}
