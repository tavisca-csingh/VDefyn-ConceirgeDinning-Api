using ConceirgeDinning.Adapter.Geocode.XYZ.Translator;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocode.XYZ.ServiceImplementation
{
    public class LocalityGeocodeFetcher : IFetchGeocode
    {

        public LocalityGeocode GetRestaurantGeocode(string locality)
        {
            WebClient client = new WebClient();
            //restaurantGeocode.Longitude = 0.00; restaurantGeocode.Latitude = 0.00; restaurantGeocode.CountryName = string.Empty;
            string url = "https://geocode.xyz/?locate=" + locality + "&json=1";
            var reply = client.DownloadString(url);
            return LocalityGeocodeTranslator.GetLocalityGeocode(reply);

        }
    }
}
