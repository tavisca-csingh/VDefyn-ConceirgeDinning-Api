namespace ConceirgeDinning.Adapter.Zomato.Models
{
    public class PhotoDetails
    {
        public string id { get; set; }
        public string url { get; set; }
        public string thumb_url { get; set; }
        public User user { get; set; }
        public long res_id { get; set; }
        public string caption { get; set; }
        public long timestamp { get; set; }
        public string friendly_time { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int comments_count { get; set; }
        public int likes_count { get; set; }
    }
}