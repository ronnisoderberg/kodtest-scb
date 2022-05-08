using Microsoft.AspNetCore.Identity;

namespace GeoComment.Models
{
    public class User : IdentityUser
    {
        public List<Comment> Comments { get; set; }
      
    }
}
