using GeoComment.Data;
using GeoComment.Models;
using Microsoft.AspNetCore.Mvc;





namespace GeoComment.Controllers
{
    [ApiController]
    [Route("api/geo-comments")]


    public class GeoCommentControllerv02 : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public GeoCommentControllerv02(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]

        public async Task<ActionResult> OnPost(Comment input)
        {
            await _ctx.Comments.AddAsync(input);
            await _ctx.SaveChangesAsync();
            return Created("", input);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _ctx.Comments.FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                return comment;
            }
            else
            {
                return StatusCode(404);
            }

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
