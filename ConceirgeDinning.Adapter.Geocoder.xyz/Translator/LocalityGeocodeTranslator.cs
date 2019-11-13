using ConceirgeDinning.Adapter.Geocoder.xyz.Models;
using ConceirgeDinning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Translator
{
    public static class LocalityGeocodeTranslator
    {
        public static LocalityGeocode GetLatLong(this LocalityVerboseGeocode reply)
        {
            LocalityGeocode localityGeocode = new LocalityGeocode();
            localityGeocode.Latitude = reply.results[0].geometry.location.lat.ToString();
            localityGeocode.Longitude = reply.results[0].geometry.location.lng.ToString();
            return localityGeocode;
        }
    }
}
