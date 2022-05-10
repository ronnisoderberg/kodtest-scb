using System.ComponentModel.DataAnnotations;

namespace GeoComment.Models
{
    public class Comment
    {
        public string? author { get; set; }
        public int Id { get; set; }

        public int longitude { get; set; }
        public int latitude { get; set; }
        public string? message { get; set; }
        public string? titel { get; set; }
        


        //Navigation propeties 
        public User? User { get; set; }
    }
}