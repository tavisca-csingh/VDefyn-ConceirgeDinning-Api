using ConceirgeDining.Adapter.TimeZoneDB.Models;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Adapter.TimeZoneDB.Translator
{
    public class TimeZoneDBTranslator
    {
        public static string GetTimeZone(TimeZoneDBResponse timeZoneDBResponse)
        {
            
            TimeSpan time = TimeSpan.FromSeconds(timeZoneDBResponse.gmtOffset);
            string sign = (timeZoneDBResponse.gmtOffset > 0) ? "+" : "-";
            string timeOffSet = time.ToString(@"hh\:mm");
            return sign + timeOffSet;
        }
    }
}
