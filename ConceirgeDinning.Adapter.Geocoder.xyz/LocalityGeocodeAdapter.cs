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
        private readonly string _googleGeocodeUrl;
        private readonly string _googleGeocodeKey;
        public LocalityGeocodeAdapter(string url,string key)
        {
            this._googleGeocodeUrl = url;
            this._googleGeocodeKey = key;
        }
        public LocalityGeocode FetchCoordinates(string locality,string latitude,string longitude)
        {
            var request = System.Net.WebRequest.Create(_googleGeocodeUrl + locality+"&bounds="+latitude+','+longitude+"|"+ latitude + ',' + longitude + "&key="+_googleGeocodeKey);
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
                        var localityGeocodeTranslator = JsonConvert.DeserializeObject<LocalityVerboseGeocode>(result);
                        Log.Information("request to supplier" + _googleGeocodeUrl + locality + "&json=1"+"\n response from Google Geocode: " + result);
                        return localityGeocodeTranslator.GetLatLong();
                    }

                    catch(Exception ex)
                    {
                        Log.Error("request to supplier" + _googleGeocodeUrl + locality + "&json=1"+"\n response from GoogleGeocode :" + ex);
                        return null;
                    }
                    
                }
            }
        }
    }
}
