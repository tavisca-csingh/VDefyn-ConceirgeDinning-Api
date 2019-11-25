using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class AppSettingsModel
    {
        public string USRestaurantURL { get; set; }
        public string USrestaurantDetailsUrl { get; set; }
        public string USrestaurantMenuUrl { get; set; }
        public string USRestaurantKey { get; set; }
        public string GoogleGeocodeURL { get; set; }
        public string GoogleGeocodeKey { get; set; }
        public string DialogFlowUrl { get; set; }
        public string TimeZoneURL { get; set; }
        public string TimeZoneApiKey { get; set; }
        public string ZomatoURL { get; set; }
        public string ZomatoRestrauntdetailsUrl { get; set; }
        public string ZomatoKey { get; set; }
        public string ZomatoMenuItemUrl { get; set; }
        public string DialogflowProjectId { get; set; }
    }
}
