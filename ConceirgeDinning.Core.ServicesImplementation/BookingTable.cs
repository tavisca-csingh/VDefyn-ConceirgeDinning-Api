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
        public List<RestarauntDetails> fetchRestarauntDetails(string locality)
        {
            RestarauntGeocodeFetcher restarauntGeocodeFetcher = new RestarauntGeocodeFetcher();
            var response= restarauntGeocodeFetcher.FetchCordinates(locality);
            RestarauntByLocalityFetcherZomato restarauntByLocalityFetcherZomato = new RestarauntByLocalityFetcherZomato();
            var reply=restarauntByLocalityFetcherZomato.FetchRestarauntDetails(response.Latitude,response.Longitude,response.CountryName);
            RestarauntByLocalityFetcherUSRestaraunt restarauntByLocalityFetcherUSRestaraunt = new RestarauntByLocalityFetcherUSRestaraunt();
            var reply2=restarauntByLocalityFetcherUSRestaraunt.FetchRestarauntDetails(response.Latitude, response.Longitude, response.CountryName);
            reply.AddRange(reply2);
            return reply;
        }

    }
}
