namespace ConceirgeDinning.Adapter.Zomato.Models
{
    public class RestaurantDetails
    {
        public Services R { get; set; }
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
        public string[] highlights { get; set; }
        public string[] offers { get; set; }
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
        public Photo[] photos { get; set; }
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
        public string[] establishment { get; set; }
        public int[] establishment_types { get; set; }
        public int? medio_provider { get; set; }
        public string book_url { get; set; }
    }
}