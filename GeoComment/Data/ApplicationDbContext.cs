using GeoComment.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoComment.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }  

    }
}
