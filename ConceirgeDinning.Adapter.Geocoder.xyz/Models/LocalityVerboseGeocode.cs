using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Models
{
    public class LocalityVerboseGeocode
    {
        public Address standard { get; set; }
        public string longt { get; set; }
        public Alternatives alt { get; set; }
        public Elevation elevation { get; set; }
        public string latt { get; set; }
    }

    public class Alternatives
    {
    }

    public class Elevation
    {
    }
}
