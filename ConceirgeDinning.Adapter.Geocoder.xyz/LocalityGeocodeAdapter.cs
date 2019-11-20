using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConceirgeDinning.Adapter.Geocoder.xyz.Models;
using ConceirgeDinning.Adapter.Geocoder.xyz.Translator;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinningContracts.Services;
using Newtonsoft.Json;
using Serilog;

namespace ConceirgeDinning.Adapter.Geocoder.xyz
{
    public class LocalityGeocodeAdapter : IFetchGeocode
    {
        public LocalityGeocode FetchCoordinates(string locality)
        {
            string ApiUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=";
            var request = System.Net.WebRequest.Create(ApiUrl + locality + "&key=AIzaSyC2LnC7a1z5MDzBjx4Us9qo9Z4Yupum03A");
            request.Method = "GET";
            request.ContentType = "application/json";

            Log.Information("request to supplier"+ ApiUrl + locality + "&json=1");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        var localityGeocodeTranslator = JsonConvert.DeserializeObject<LocalityVerboseGeocode>(result);
                        Log.Information("response from supplier: " + result);
                        return localityGeocodeTranslator.GetLatLong();
                    }

                    catch(Exception ex)
                    {
                        Log.Information("response from supplier :" + ex);
                        return null;
                    }
                    
                }
            }
        }
    }
}
