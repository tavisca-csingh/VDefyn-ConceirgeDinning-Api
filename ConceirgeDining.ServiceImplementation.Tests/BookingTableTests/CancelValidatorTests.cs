using ConceirgeDiningDAL.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConceirgeDining.ServiceImplementation.Tests.BookingTableTests
{
    public class CancelValidatorTests
    {
        Booking booking = new Booking();
        CancellValidator cancellValidator = new CancellValidator();

        [Fact]
        public void Check_For_Valid_Booking_Id()
        {
            bool actual = cancellValidator.CheckBookingId(booking);
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Invalid_Booking_Id()
        {
            bool actual = cancellValidator.CheckBookingId(null);
            Assert.False(actual);
        }

        [Fact]
        public void Check_When_Cancel_Status_Is_True()
        {
            booking.Status = "Cancelled";
            bool actual = cancellValidator.CheckCancellStatus(booking);
            Assert.False(actual);
        }

        [Fact]
        public void Check_When_Cancel_Status_Is_False()
        {
            booking.Status = "Booked";
            bool actual = cancellValidator.CheckCancellStatus(booking);
            Assert.True(actual);
        }

        [Fact]
        public void Check_Cancel_Time_Duration_Of_Previous_Date()
        {
            booking.Date = DateTime.Parse("2019/02/01");
            bool actual = cancellValidator.CheckCancelTime(booking);
            Assert.False(actual);
        }

        [Fact]
        public void Check_Cancel_Time_Duration_Of_Valid_Date()
        {
            booking.Date = DateTime.Now.AddDays(1);
            bool actual = cancellValidator.CheckCancelTime(booking);
            Assert.True(actual);
        }

        [Fact]
        public void Check_Cancel_Time_Duration_Of_Invalid_Time()
        {
            booking.Time = DateTime.Today.TimeOfDay.Add(new TimeSpan(1, 1, 1));
            bool actual = cancellValidator.CheckCancelTime(booking);
            Assert.False(actual);
        }
    }
}
