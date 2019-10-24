using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Models
{
    public class HasMenuStatus
    {
        public int delivery { get; set; }
        public int takeaway { get; set; }
    }

    public class R
    {
        public HasMenuStatus has_menu_status { get; set; }
        public int res_id { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string locality { get; set; }
        public string city { get; set; }
        public int city_id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string zipcode { get; set; }
        public int country_id { get; set; }
        public string locality_verbose { get; set; }
    }

    public class Title
    {
        public string text { get; set; }
    }

    public class BgColor
    {
        public string type { get; set; }
        public string tint { get; set; }
    }

    public class RatingObj
    {
        public Title title { get; set; }
        public BgColor bg_color { get; set; }
    }

    public class UserRating
    {
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public RatingObj rating_obj { get; set; }
        public string votes { get; set; }
        public string custom_rating_text { get; set; }
        public string custom_rating_text_background { get; set; }
        public string rating_tool_tip { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string foodie_level { get; set; }
        public int foodie_level_num { get; set; }
        public string foodie_color { get; set; }
        public string profile_url { get; set; }
        public string profile_image { get; set; }
        public string profile_deeplink { get; set; }
        public string zomato_handle { get; set; }
    }

    public class Photo2
    {
        public string id { get; set; }
        public string url { get; set; }
        public string thumb_url { get; set; }
        public User user { get; set; }
        public int res_id { get; set; }
        public string caption { get; set; }
        public int timestamp { get; set; }
        public string friendly_time { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Photo
    {
        public Photo2 photo { get; set; }
    }

    public class AllReviews
    {
        public List<object> reviews { get; set; }
    }

    public class Photo4
    {
        public string url { get; set; }
        public string thumb_url { get; set; }
        public int order { get; set; }
        public string md5sum { get; set; }
        public int id { get; set; }
        public int photo_id { get; set; }
        public object uuid { get; set; }
        public string type { get; set; }
    }

    public class Photo3
    {
        public Photo4 photo { get; set; }
    }

    public class ShareData
    {
        public int should_show { get; set; }
    }

    public class Event
    {
        public int event_id { get; set; }
        public string friendly_start_date { get; set; }
        public string friendly_end_date { get; set; }
        public string friendly_timing_str { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string end_time { get; set; }
        public string start_time { get; set; }
        public int is_active { get; set; }
        public string date_added { get; set; }
        public List<Photo3> photos { get; set; }
        public List<object> restaurants { get; set; }
        public int is_valid { get; set; }
        public string share_url { get; set; }
        public int show_share_url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string display_time { get; set; }
        public string display_date { get; set; }
        public int is_end_time_set { get; set; }
        public string disclaimer { get; set; }
        public int event_category { get; set; }
        public string event_category_name { get; set; }
        public string book_link { get; set; }
        public List<object> types { get; set; }
        public ShareData share_data { get; set; }
    }

    public class ZomatoEvent
    {
        public Event @event { get; set; }
    }

    public class Restaurant2
    {
        public R R { get; set; }
        public string apikey { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Location location { get; set; }
        public int switch_to_order_menu { get; set; }
        public string cuisines { get; set; }
        public string timings { get; set; }
        public int average_cost_for_two { get; set; }
        public int price_range { get; set; }
        public string currency { get; set; }
        public List<object> highlights { get; set; }
        public List<object> offers { get; set; }
        public int opentable_support { get; set; }
        public int is_zomato_book_res { get; set; }
        public string mezzo_provider { get; set; }
        public int is_book_form_web_view { get; set; }
        public string book_form_web_view_url { get; set; }
        public string book_again_url { get; set; }
        public string thumb { get; set; }
        public UserRating user_rating { get; set; }
        public int all_reviews_count { get; set; }
        public string photos_url { get; set; }
        public int photo_count { get; set; }
        public List<Photo> photos { get; set; }
        public string menu_url { get; set; }
        public string featured_image { get; set; }
        public int has_online_delivery { get; set; }
        public int is_delivering_now { get; set; }
        public bool include_bogo_offers { get; set; }
        public string deeplink { get; set; }
        public string order_url { get; set; }
        public string order_deeplink { get; set; }
        public int is_table_reservation_supported { get; set; }
        public int has_table_booking { get; set; }
        public string events_url { get; set; }
        public string phone_numbers { get; set; }
        public AllReviews all_reviews { get; set; }
        public List<object> establishment { get; set; }
        public List<object> establishment_types { get; set; }
        public List<ZomatoEvent> zomato_events { get; set; }
        public int? medio_provider { get; set; }
        public string book_url { get; set; }
    }

    public class Restaurant1
    {
        public Restaurant2 restaurant { get; set; }
    }

    public class ZomatoRestaurant
    {
        public int results_found { get; set; }
        public int results_start { get; set; }
        public int results_shown { get; set; }
        public List<Restaurant1> restaurants { get; set; }
    }
}
