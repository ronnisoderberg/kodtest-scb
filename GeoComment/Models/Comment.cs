namespace GeoComment.Models
{
    public class Comment 
    {
        public string author { get; set; }
        public int Id { get; set; }

        public double longitude { get; set; }
        public double latitude { get; set; }
        public string message { get; set; }
    }
}
