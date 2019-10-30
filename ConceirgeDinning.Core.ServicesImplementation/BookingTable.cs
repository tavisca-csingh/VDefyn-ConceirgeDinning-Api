using System;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;
using ConceirgeDinning.Services;
using System.Collections.Generic;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using System.Threading.Tasks;
using ConceirgeDinning.Adapter.Geocoder.xyz.Models;

namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class BookingTable:IBookTable
    {
        List<IFetchRestaurant> restaurantByLocalityFetchers = new List<IFetchRestaurant>()
        {
            new ZomatoRestarauntAdapter(),
            new USRestarauntAdapter()
        };
        public List<Restaurant> fetchRestarauntDetails(string locality)
        {
            LocalityGeocodeAdapter restarauntGeocodeFetcher = new LocalityGeocodeAdapter();
            var coordinates= restarauntGeocodeFetcher.FetchCoordinates(locality);
            if (coordinates.CountryName is null)
                return null;


           
            ZomatoRestarauntAdapter zomatoRestaurantList = new ZomatoRestarauntAdapter();
            USRestarauntAdapter usRestaurantList = new USRestarauntAdapter();
            Task<List<Restaurant>> fetchFromZomato = Task<List<Restaurant>>.Run(() => zomatoRestaurantList.FetchRestarauntDetails(coordinates));
            //Task<List<Restaurant>> fetchFromUS = Task<List<Restaurant>>.Run(() => usRestaurantList.FetchRestarauntDetails(coordinates));
            Task[] searchTasks = { /*fetchFromUS,*/ fetchFromZomato };
            Task.WaitAll(searchTasks);

           
            var zomatoResults = fetchFromZomato.Result;
            //var usRestaurantResults = fetchFromUS.Result;
            //zomatoResults.AddRange(usRestaurantResults);
            
            
            return zomatoResults;
        }

    }
}
