namespace HackerNewsApi2.Models
{
    public class Story
    {
        public string title { get; set; }
        public string url { get; set; }
        public string by { get; set; }
        public string time { get; set; }
        public int score { get; set; }
        public string descendants { get; set; }
    }
}
