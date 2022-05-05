using GeoComment.Data;
using GeoComment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;





namespace GeoComment.Controllers
{
    [ApiController]
    [Route("api/geo-comments")]



    public class GeoCommentControllerv02 : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;
        private readonly object _userManager;

        public GeoCommentControllerv02(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            //_userManager = userManager;
        }



        //[HttpPost]
        //[ApiVersion("0.2")]
        //public async Task<ActionResult> OnPost(Comment input)
        //{
        //    await _ctx.Comments.AddAsync(input);
        //    await _ctx.SaveChangesAsync();
        //    return Created("", input);
        //}
        [HttpPost]
        [Route("{id:int}")]
        public ActionResult<Comment> PostComment(Comment input)
        {

            var newComment = new Comment
            {

            };
            

            _ctx.Comments.Add(newComment);
            _ctx.SaveChanges();
            return Created("", newComment);

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

