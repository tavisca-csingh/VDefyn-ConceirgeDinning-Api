using System;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;
using ConceirgeDinning.Services;
using System.Collections.Generic;
using ConceirgeDinning.Adapter.Zomato.Translator;

namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class BookingTable:IBookTable
    {
        public List<RestarauntDetails> fetchRestarauntDetails(string locality)
        {
            RestarauntGeocodeFetcher restarauntGeocodeFetcher = new RestarauntGeocodeFetcher();
            var response= restarauntGeocodeFetcher.FetchCordinates(locality);
            RestarauntByLocalityFetcher restarauntByLocalityFetcher = new RestarauntByLocalityFetcher();
            return restarauntByLocalityFetcher.FetchRestarauntDetails(response.Latitude,response.Longitude,response.CountryName);
        }

    }
}
