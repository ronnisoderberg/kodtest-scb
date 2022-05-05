using System.ComponentModel.DataAnnotations;

namespace GeoComment.Models
{
    public class Comment 
    {
        public string author { get; set; }
        [Key]
        public int Id { get; set; }

        public double longitude { get; set; }
        public double latitude { get; set; }
        public string message { get; set; }

        public User User { get; set; }  
    }
}
