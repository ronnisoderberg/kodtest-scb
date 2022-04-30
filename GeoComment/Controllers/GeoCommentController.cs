using GeoComment;
using Microsoft.AspNetCore.Mvc;

namespace testforwether.Controllers
{
    [ApiController]
    [Route("api/geo-comments")]
    public class GeoCommentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GeoCommentController> _logger;

        public GeoCommentController(ILogger<GeoCommentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ResetDB()
        {
            
            return Ok("rar");
        }

    }
}