using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt.Models
{
    public class Geo
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string formatted { get; set; }
        public string street { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
    }

    public class Datum
    {
        public Geo geo { get; set; }
        public string hours { get; set; }
        public Address address { get; set; }
        public string restaurant_phone { get; set; }
        public int restaurant_id { get; set; }
        public string price_range { get; set; }
        public List<object> menus { get; set; }
        public int price_range_100 { get; set; }
        public List<object> cuisines { get; set; }
        public string restaurant_name { get; set; }
    }

    public class Result
    {
        public int totalResults { get; set; }
        public List<Datum> data { get; set; }
        public int numResults { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public bool morePages { get; set; }
    }

    public class RestarauntByLocality
    {
        public Result result { get; set; }
    }
}
