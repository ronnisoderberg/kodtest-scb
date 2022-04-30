namespace GeoComment.Models
{
    public class Comment
    {
        public string author { get; set; }
        public int Id { get; set; }

        public string longitude { get; set; }
        public string latitude { get; set; }
        public string message { get; set; } 
    }
}
