using ConceirgeDining.Adapter.TimeZoneDB.Models;
using ConceirgeDining.Adapter.TimeZoneDB.Translator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDining.Adapter.TimeZoneDB
{
    public class TimeZoneDBAdapter
    {
        private readonly string _timezoneUrl;
        private readonly string _timeZoneKey;
        public TimeZoneDBAdapter(string url,string key)
        {
            this._timezoneUrl = url;
            this._timeZoneKey = key;
        }
        public string FetchTimeZone(string latitude, string longitude)
        {

            string ApiUrl = _timezoneUrl + latitude + "&lng=" + longitude;
            var request = System.Net.WebRequest.Create(ApiUrl + "&key="+_timeZoneKey);
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
                        var timeZoneDBResponse = JsonConvert.DeserializeObject<TimeZoneDBResponse>(result);
                        var gmtTimeZone = TimeZoneDBTranslator.GetTimeZone(timeZoneDBResponse);
                        return gmtTimeZone;
                    }

                    catch (Exception e)
                    {

                        throw e;
                    }
                }

            }
        }
    }
}
