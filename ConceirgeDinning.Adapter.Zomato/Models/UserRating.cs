namespace ConceirgeDinning.Adapter.Zomato.Models
{
    public class UserRating
    {
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public Rating rating_obj { get; set; }
        public string votes { get; set; }
    }
}