using ConceirgeDining.Adapter.TimeZoneDB;
using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation.BookingTable
{
    public class BookingValidator
    {
        public int CheckAvailability(int noOfGuests, DateTime date, string restaurantId,string restaurantName)
        {
            sql12310325Context conciergeContext = new sql12310325Context();
            int bookedSeats;
            var restaurantDetails=conciergeContext.RestaurantNames.Find(restaurantId);
            if (restaurantDetails == null)
            {
                //stores restaurent name
                RestaurantNames restaurantNames = new RestaurantNames();
                restaurantNames.RestaurantId = restaurantId;
                restaurantNames.RestaurantName = restaurantName;
                conciergeContext.RestaurantNames.Add(restaurantNames);
                conciergeContext.SaveChanges();

                RestaurantAvailability restaurantAvailability = new RestaurantAvailability();
                restaurantAvailability.RestaurantId = restaurantId;
                restaurantAvailability.BookingDate = date;
                restaurantAvailability.BookedSeats = 0;
                conciergeContext.RestaurantAvailability.Add(restaurantAvailability);
                conciergeContext.SaveChanges();
                bookedSeats = 0;
            }
            else
            {


                var restaurantAvailabilityDetails = conciergeContext.RestaurantAvailability.Find(restaurantId, date);
                if (restaurantAvailabilityDetails == null)
                {
                    RestaurantAvailability restaurantAvailability = new RestaurantAvailability();
                    restaurantAvailability.RestaurantId = restaurantId;
                    restaurantAvailability.BookingDate = date;
                    restaurantAvailability.BookedSeats = 0;
                    conciergeContext.RestaurantAvailability.Add(restaurantAvailability);
                    conciergeContext.SaveChanges();
                    bookedSeats = 0;
                }
                else
                    bookedSeats = conciergeContext.RestaurantAvailability.Find(restaurantId, date).BookedSeats;
            }
            
            return bookedSeats;
        }
        public bool CheckNoOfGuests(int noOfGuests)
        {
            if (noOfGuests > 15 || noOfGuests < 1)
                return false;
            else
                return true;
        }
        public bool CheckDateTime(string dateTime,string latitude,string longitude,out string UTCTime)
        {

            DateTime currentdateTime= DateTime.UtcNow;
            TimeZoneDBAdapter timeZoneDBAdapter = new TimeZoneDBAdapter();
            string gmtOffset = timeZoneDBAdapter.FetchTimeZone(latitude, longitude);
            dateTime += gmtOffset;
            DateTime bookingDateTime = DateTimeOffset.Parse(dateTime).UtcDateTime;
            UTCTime = bookingDateTime.ToString();
            if (currentdateTime <= bookingDateTime)
                return true;
            return false;
        }
        public bool CheckPointAvailability(int noOfGuests,long perPersonPoints, long pointBalance)
        {
            long totalPointsRequired = noOfGuests * perPersonPoints;
            if (totalPointsRequired <= pointBalance)
                return true;
            return false;
        }
    }
}
