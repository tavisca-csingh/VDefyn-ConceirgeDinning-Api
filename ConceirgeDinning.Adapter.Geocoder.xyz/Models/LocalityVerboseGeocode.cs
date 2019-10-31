using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Models
{
    public class Standard
    {
        public object addresst { get; set; }
        public string city { get; set; }
        public string prov { get; set; }
        public string countryname { get; set; }
        public object postal { get; set; }
        public string confidence { get; set; }
    }

    public class Alt
    {
    }

    public class Elevation
    {
    }

    public class LocalityVerboseGeocode
    {
        public Standard standard { get; set; }
        public string longt { get; set; }
        public Alt alt { get; set; }
        public Elevation elevation { get; set; }
        public string latt { get; set; }
    }
}
