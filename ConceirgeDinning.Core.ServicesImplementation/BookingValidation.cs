using ConceirgeDiningDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.ServicesImplementation
{
    public class BookingValidation
    {
        public bool CheckAvailability(int noOfGuests, DateTime date, string restaurantId,string restaurantName)
        {
            sql12310325Context conciergeContext = new sql12310325Context();
            var reply=conciergeContext.RestaurantNames.Find(restaurantId);
            if (reply == null)
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
            }
            var reply2 = conciergeContext.RestaurantAvailability.Find(restaurantId, date);
            if(reply2==null)
            {
                RestaurantAvailability restaurantAvailability = new RestaurantAvailability();
                restaurantAvailability.RestaurantId = restaurantId;
                restaurantAvailability.BookingDate = date;
                restaurantAvailability.BookedSeats = 0;
                conciergeContext.RestaurantAvailability.Add(restaurantAvailability);
                conciergeContext.SaveChanges();
            }
            reply2 = conciergeContext.RestaurantAvailability.Find(restaurantId, date);
            if ((40 - reply2.BookedSeats) >= noOfGuests)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckNoOfGuests(int noOfGuests)
        {
            if (noOfGuests > 15 || noOfGuests < 1)
                return false;
            else
                return true;
        }
        public bool CheckDate(DateTime date)
        {
            DateTime currentdate= DateTime.Today;
            if (currentdate <= date)
                return true;
            return false;
        }
        public bool CheckTime(TimeSpan time)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            if (currentTime < time)
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
