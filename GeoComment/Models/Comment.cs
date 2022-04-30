namespace GeoComment.Models
{
    public class Comment
    {
        public string author { get; set; }
        public int Id { get; set; }

        public string longitude { get; set; }
        public double latitude { get; set; }
        public double message { get; set; } 
    }
}
