using ConceirgeDinning.ServicesImplementation.BookingTable;
using System;
using Xunit;

namespace ConceirgeDining.ServiceImplementation.Tests.BookingTableTests
{
    public class BookingValidatorTests
    {
        BookingValidator bookingValidator = new BookingValidator();

        [Fact]
        public void Check_Number_Of_Guests_For_Negative_Guest_Count()
        {
            bool actual = bookingValidator.CheckNoOfGuests(-5);
            Assert.False(actual);
        }

        [Fact]
        public void Check_Number_Of_Guests_For_Valid_Positive_Guest_Count()
        {
            bool actual = bookingValidator.CheckNoOfGuests(5);
            Assert.True(actual);
        }

        [Fact]
        public void Check_Number_Of_Guests_For_Invalid_Positive_Guest_Count()
        {
            bool actual = bookingValidator.CheckNoOfGuests(25);
            Assert.False(actual);
        }

        [Fact]
        public void Check_Number_Of_Guests_For_Zero_Guest_Count()
        {
            bool actual = bookingValidator.CheckNoOfGuests(0);
            Assert.False(actual);
        }

        [Fact]
        public void Check_For_Valid_Date()
        {
            DateTime dateTime = DateTime.Today;
            string UTCTime = "0001-01-01T00:00:00+00:00";
            bool actual = bookingValidator.CheckDateTime(dateTime.ToString(),"18.5204","73.8567",out UTCTime);
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Invalid_Date()
        {
            DateTime dateTime = DateTime.Parse("2019/02/01");
            string UTCTime = "0001-01-01T00:00:00+00:00";
            bool actual = bookingValidator.CheckDateTime(dateTime.ToString(), "18.5204", "73.8567",out UTCTime);
            Assert.False(actual);
        }

        

        

        [Fact]
        public void Check_For_Sufficient_Points()
        {
            long pointBalance = 12000;
            long perPersonPoints = 3000;
            int noOfGuests = 3;
            bool actual = bookingValidator.CheckPointAvailability(noOfGuests, perPersonPoints, pointBalance);
            Assert.True(actual);
        }

        [Fact]
        public void Check_For_Insufficient_Points()
        {
            long pointBalance = 12000;
            long perPersonPoints = 3000;
            int noOfGuests = 8;
            bool actual = bookingValidator.CheckPointAvailability(noOfGuests, perPersonPoints, pointBalance);
            Assert.False(actual);
        }
    }
}
