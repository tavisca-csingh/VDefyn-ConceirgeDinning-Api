using System;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;
using ConceirgeDinning.Services;
using System.Collections.Generic;
using ConceirgeDinning.Adapter.Zomato.Translator;
using ConceirgeDinning.Adapter.USRestaraunt.Translator;

namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class BookingTable:IBookTable
    {
        public List<RestarauntByLocality> fetchRestarauntDetails(string locality)
        {
            RestarauntGeocodeFetcher restarauntGeocodeFetcher = new RestarauntGeocodeFetcher();
            var response= restarauntGeocodeFetcher.FetchCordinates(locality);
            RestarauntFetcherByLocalityZomato restarauntByLocalityFetcherZomato = new RestarauntFetcherByLocalityZomato();
            var reply=restarauntByLocalityFetcherZomato.FetchRestarauntDetails(response.Latitude,response.Longitude,response.CountryName);
            RestarauntFetcherByLocalityUSRestaraunt restarauntByLocalityFetcherUSRestaraunt = new RestarauntFetcherByLocalityUSRestaraunt();
            var reply2=restarauntByLocalityFetcherUSRestaraunt.FetchRestarauntDetails(response.Latitude, response.Longitude, response.CountryName);
            reply.AddRange(reply2);
            return reply;
        }

    }
}
