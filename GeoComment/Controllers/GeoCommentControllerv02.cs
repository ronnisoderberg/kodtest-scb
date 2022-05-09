using GeoComment.Data;
using GeoComment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace GeoComment.Controllers
{
    [ApiController]
    [Route("api/geo-comments")]



    public class GeoCommentControllerv02 : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<User> _userManager;

        public GeoCommentControllerv02(ApplicationDbContext ctx, UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }



        
        [HttpPost]
        [ApiVersion("0.2")]
        [Authorize]

        public async Task<ActionResult<CommentV2>> PostComment(CommentV2 input)
        {
            input.body.author = _userManager.GetUserName(User);
            var oldComment = new Comment()
            {
                Id = input.Id,
                message = input.body.message,
                author = input.body.author,
                latitude = input.latitude,
                longitude = input.longitude,

            };
            _ctx.Comments.Add(oldComment);
            _ctx.SaveChanges();

            var newComment = new CommentV2
            {

                Id = oldComment.Id,
                body = new Body
                {
                    author = input.body.author,
                    title = input.body.title,
                    message = input.body.message
                },
                longitude = input.longitude,
                latitude = input.latitude,

            };




            return Created("", newComment);

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



        [HttpGet]
        public ActionResult<IEnumerable<Comment>> OnGet(double? minLon, double? maxLon, double? minLat, double? maxLat)
        {

            if (maxLat != null && minLat != null && maxLon != null && minLon != null)
            {
                var pos = _ctx.Comments.Where(
                    x => x.latitude >= minLat
                         && x.latitude <= maxLat
                         && x.longitude >= minLon
                         && x.longitude <= maxLat).ToList();
                return Ok(pos);
            }

            return StatusCode(400);
        }
    }
}

