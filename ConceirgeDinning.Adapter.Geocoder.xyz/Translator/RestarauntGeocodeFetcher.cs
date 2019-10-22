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
        public RestarauntGeocode FetchCordinates(string locality)
        {
            WebClient client = new WebClient();
            RestarauntGeocode restarauntGeocode = new RestarauntGeocode();
            restarauntGeocode.Longitude = 0.00; restarauntGeocode.Latitude = 0.00;restarauntGeocode.CountryName = string.Empty;
            string url = "https://geocode.xyz/?locate=" + locality + "&json=1";
            var reply = client.DownloadString(url);
            if (!reply.Contains("\"0.00000\""))
            {
                var jobject=JsonConvert.DeserializeObject<RestarauntGeocodebyLocalityVerbose>(reply);
                restarauntGeocode.Latitude = Convert.ToDouble(jobject.latt);
                restarauntGeocode.Longitude= Convert.ToDouble(jobject.longt);
                restarauntGeocode.CountryName =jobject.standard.countryname;
                return restarauntGeocode;
            }
            return restarauntGeocode;
        }
    }
}
