using System;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;
using ConceirgeDinning.Services;
using System.Collections.Generic;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using System.Threading.Tasks;

namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class BookingTable:IBookTable
    {
        List<IRestaurantByLocalityFetcher> restaurantByLocalityFetchers = new List<IRestaurantByLocalityFetcher>()
        {
            new ZomatoRestarauntByLocalityFetcher(),
            new USRestarauntByLocalityFetcher()
        };
        public List<Restaurant> fetchRestarauntDetails(string locality)
        {
            RestarauntGeocodeFetcher restarauntGeocodeFetcher = new RestarauntGeocodeFetcher();
            var coordinates= restarauntGeocodeFetcher.FetchCordinates(locality);


           
            ZomatoRestarauntByLocalityFetcher zomatoRestaurantList = new ZomatoRestarauntByLocalityFetcher();
            USRestarauntByLocalityFetcher usRestaurantList = new USRestarauntByLocalityFetcher();
            Task<List<Restaurant>> fetchFromZomato = Task<List<Restaurant>>.Run(() => zomatoRestaurantList.FetchRestarauntDetails(coordinates));
            Task<List<Restaurant>> fetchFromUS = Task<List<Restaurant>>.Run(() => usRestaurantList.FetchRestarauntDetails(coordinates));
            Task[] searchTasks = { fetchFromUS, fetchFromZomato };
            Task.WaitAll(searchTasks);
            var zomatoResults = fetchFromZomato.Result;
            var usRestaurantResults = fetchFromUS.Result;
            zomatoResults.AddRange(usRestaurantResults);
            
            return zomatoResults;
        }

    }
}
