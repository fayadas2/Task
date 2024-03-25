namespace TaskBamboo.Models
{
    public class StoriesModel
    {
        public string? title { get; set; }
        public string? url { get; set; }
        public string? postedBy { get; set; }
        public DateTime? time { get; set; }
        public int score { get; set; }
        public int commentCount { get; set; }

    }
    public class StoriesAPIModel
    {
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

    }


}
