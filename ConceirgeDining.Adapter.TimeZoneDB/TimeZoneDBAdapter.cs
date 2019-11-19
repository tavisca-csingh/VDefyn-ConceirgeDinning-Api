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
        public string FetchTimeZone(string latitude, string longitude)
        {
            string ApiUrl = "http://api.timezonedb.com/v2.1/get-time-zone?format=json&by=position&lat=" + latitude + "&lng=" + longitude;
            var request = System.Net.WebRequest.Create(ApiUrl + "&key=Q62ZT7QSP0O6");
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

                    catch (Exception ex)
                    {

                        return null;
                    }
                }

            }
        }
    }
}
