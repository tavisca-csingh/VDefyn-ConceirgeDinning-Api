using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Models
{
    public class LocalityVerboseGeocode
    {
        public List<object> html_attributions { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}
