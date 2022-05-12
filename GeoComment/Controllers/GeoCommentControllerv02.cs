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
                titel = input.body.title


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



       

        [ApiVersion("0.2")]
        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<CommentV2>>GetCommentFromUser(int Id)
        {


            var commentFromUser = _ctx.Comments.FirstOrDefault(x => x.Id == Id);
            if (commentFromUser == null)
            {
                return  NotFound();
            }

            var newComment = new CommentV2()
            {

                Id = commentFromUser.Id,
                body = new Body
                {
                    author = commentFromUser.author,
                    title = commentFromUser.titel,
                    message = commentFromUser.message,
                },
                longitude = commentFromUser.longitude,
                latitude = commentFromUser.latitude,

            };

            return Ok(newComment);

        }

        [ApiVersion("0.2")]
        [HttpGet]
        [Route("{username}")]

        public async Task<ActionResult> GetCommentsFromUser(string username)
        {
            var usersComments = await _ctx.Comments.Where(x => x.author == username).ToArrayAsync();

            if (usersComments.Length == 0)
                return NotFound();
            
                
            
            
            List<CommentV2> comments = new List<CommentV2>();
            

            foreach (var user in usersComments)
                comments.Add(new CommentV2()
                {
                    Id = user.Id,
                    body = new Body()
                    {
                        author = username,
                        title = user.titel,
                        message = user.message
                    },
                    longitude = user.longitude,
                    latitude = user.latitude,
                });

            return Ok(comments);
        }

        [ApiVersion("0.2")]
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> OnGet(double? minLon, double? maxLon, double? minLat, double? maxLat)
        {

            if (maxLat != null && minLat != null && maxLon != null && minLon != null)
            {

                var positionsComments = _ctx.Comments.Where(
                    x => x.latitude >= minLat
                         && x.latitude <= maxLat
                         && x.longitude >= minLon
                         && x.longitude <= maxLat).ToList();



                List<CommentV2> comments = new List<CommentV2>();


                foreach (var user in positionsComments)
                    comments.Add(new CommentV2()
                    {
                        Id = user.Id,
                        body = new Body()
                        {
                            author = user.author,
                            title = user.titel,
                            message = user.message
                        },
                        longitude = user.longitude,
                        latitude = user.latitude,
                    });





                return Ok(comments);
            }

            return StatusCode(400);




        }
    }
}

