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
    public class BookingTable : IBookTable
    {

        List<IFetchRestaurant> restaurantByLocalityFetchers = new List<IFetchRestaurant>()
        {
            new ZomatoRestarauntAdapter(),
            new USRestarauntAdapter()
        };

        public List<Restaurant> fetchRestarauntDetails(string locality, string latitude, string longitude)
        {
            if (locality != string.Empty)
            {
                LocalityGeocodeAdapter restarauntGeocodeFetcher = new LocalityGeocodeAdapter();
                var coordinates = restarauntGeocodeFetcher.FetchCoordinates(locality);
                if (coordinates is null)
                    return null;
                latitude = coordinates.Latitude;
                longitude = coordinates.Longitude;
            }


            ZomatoRestarauntAdapter zomatoRestaurantList = new ZomatoRestarauntAdapter();
            //USRestarauntAdapter usRestaurantList = new USRestarauntAdapter();
            Task<List<Restaurant>> fetchFromZomato = Task<List<Restaurant>>.Run(() => zomatoRestaurantList.FetchRestarauntDetails(latitude, longitude));
            //Task<List<Restaurant>> fetchFromUS = Task<List<Restaurant>>.Run(() => usRestaurantList.FetchRestarauntDetails(coordinates));
            //Task[] searchTasks = { /*fetchFromUS,*/ fetchFromZomato };
            //Task.WaitAll(searchTasks);


            var zomatoResults = fetchFromZomato.Result;
            // var usRestaurantResults = fetchFromUS.Result;
            //zomatoResults.AddRange(usRestaurantResults);


            return zomatoResults;
        }
            

    }
}
