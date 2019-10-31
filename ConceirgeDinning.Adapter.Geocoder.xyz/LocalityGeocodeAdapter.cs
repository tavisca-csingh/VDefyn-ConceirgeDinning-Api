using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConceirgeDinning.Adapter.Geocoder.xyz.Models;
using ConceirgeDinning.Core.Models;
using ConceirgeDinning.Services;
using Newtonsoft.Json;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Translator
{
    public class LocalityGeocodeAdapter : IFetchGeocode
    {
        public LocalityGeocode FetchCoordinates(string locality)
        {
            string ApiUrl = "https://geocode.xyz/?locate=";
            var request = System.Net.WebRequest.Create(ApiUrl + locality + "&json=1");
            request.Method = "GET";
            request.ContentType = "application/json";


            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        var jobject = JsonConvert.DeserializeObject<LocalityVerboseGeocode>(result);
                        var searchResults = LocalityGeocodeTranslator.GetLatLong(jobject);
                        return searchResults;
                    }

                    catch(Exception ex)
                    {
                        return null;
                    }
                    
                }
            }
        }
    }
}
