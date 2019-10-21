using System;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;


namespace ConceirgeDinning.Core.ServicesImplementation
{
    public class BookingTable
    {
        public RestarauntCoreGeocode FetchLAt(string locality)
        {
            RestarauntGeocodeFetcher restarauntGeocodeFetcher = new RestarauntGeocodeFetcher();
            return restarauntGeocodeFetcher.FetchCordinates(locality);
        }
}
}
