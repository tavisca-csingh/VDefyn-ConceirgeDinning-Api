using System.Collections.Generic;

namespace ConceirgeDinning.Adapter.Geocoder.xyz.Models
{
    public class Result
    {
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public List<string> types { get; set; }
    }
}
