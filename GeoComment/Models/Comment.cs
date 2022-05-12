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

    public class CommentV2
    {
        public int Id { get; set; }
        public Body body { get; set; }

        public int longitude { get; set; }
        public int latitude { get; set; }
    }

    public class Body
    {
        public string? author { get; set; }
        public string title { get; set; }
        public string message { get; set; }

    }
}


public class Rootobject
{
    public int response_code { get; set; }
    public Result[] results { get; set; }
}

public class Result
{
    public string category { get; set; }
    public string type { get; set; }
    public string difficulty { get; set; }
    public string question { get; set; }
    public string correct_answer { get; set; }
    public string[] incorrect_answers { get; set; }
}
