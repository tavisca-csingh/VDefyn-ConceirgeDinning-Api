using ConceirgeDinning.Adapter.Geocode.XYZ.Models;
using ConceirgeDinning.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocode.XYZ.Translator
{
    public static class LocalityGeocodeTranslator
    {
        public static LocalityGeocode GetLocalityGeocode(string reply)
        {
            LocalityGeocode restaurantGeocode = new LocalityGeocode();
            if (!reply.Contains("\"0.00000\""))
            {
                var jobject = JsonConvert.DeserializeObject<GeocodeXYZLocalityGeocode>(reply);
                restaurantGeocode.Latitude = jobject.latt;
                restaurantGeocode.Longitude = jobject.longt;
                restaurantGeocode.CountryName = jobject.standard.countryname;
                return restaurantGeocode;
            }
            return null;

        }
    }
}
