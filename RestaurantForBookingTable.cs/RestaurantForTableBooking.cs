using ConceirgeDinning.Adapter.Geocode.XYZ.ServiceImplementation;
using ConceirgeDinning.Adapter.USRestaurant.ServiceImplementation;
using ConceirgeDinning.Adapter.Zomato.ServiceImplementation;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantForBookingTable.cs
{
    public class RestaurantForTableBooking
    {

        public List<Restaurant> GetRestaurants(string locality)
        {
            LocalityGeocodeFetcher localityGeocodeFetcher = new LocalityGeocodeFetcher();
            var geocode=localityGeocodeFetcher.GetRestaurantGeocode(locality);
            if (geocode is null) return null;

            USRestaurantFetcher usrestaurantFetcher = new USRestaurantFetcher();
            ZomatoRestaurantFetcher zomatoRestaurantFetcher = new ZomatoRestaurantFetcher();

            Task<List<Restaurant>> replyFromUsRestaurant = Task<List<Restaurant>>.Run(() => usrestaurantFetcher.GetRestaurant(geocode));
            Task<List<Restaurant>> replyFromZomato = Task.Run(() => zomatoRestaurantFetcher.GetRestaurant(geocode));
            Task[] searchTasks = { replyFromUsRestaurant, replyFromZomato };
            Task.WaitAll(searchTasks);

            replyFromZomato.Result.AddRange(replyFromUsRestaurant.Result);
            return replyFromZomato.Result;
        }
    }
}
