using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ConceirgeDinning.Adapter.Geocoder.xyz.Models;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Translator
{
    public class RestarauntGeocodeFetcher : IFetchGeocode
    {
        public RestarauntCoreGeocode FetchCordinates(string locality)
        {
            WebClient client = new WebClient();
            RestarauntCoreGeocode restarauntCoreGeocode = new RestarauntCoreGeocode();
            restarauntCoreGeocode.Longitude = 0.00; restarauntCoreGeocode.Latitude = 0.00;restarauntCoreGeocode.CountryName = string.Empty;
            string url = "https://geocode.xyz/?locate=" + locality + "&json=1";
            var reply = client.DownloadString(url);
            if (!reply.Contains("\"0.00000\""))
            {
                var jobject=JsonConvert.DeserializeObject<RestarauntGeocodebyLocalityVerbose>(reply);
                restarauntCoreGeocode.Latitude = Convert.ToDouble(jobject.latt);
                restarauntCoreGeocode.Longitude= Convert.ToDouble(jobject.longt);
                restarauntCoreGeocode.CountryName =jobject.standard.countryname;
                return restarauntCoreGeocode;
            }
            return restarauntCoreGeocode;
        }
    }
}
