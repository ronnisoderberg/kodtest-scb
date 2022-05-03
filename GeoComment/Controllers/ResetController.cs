using GeoComment.Data;
using Microsoft.AspNetCore.Mvc;

namespace GeoComment.Controllers
{
    [Route("test")]
    [ApiController]
    public class ResetController : ControllerBase
    {

        private readonly ApplicationDbContext _ctx;

        public ResetController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        [Route("reset-db")]
    [ApiVersion("0.2")]
        [HttpGet]
        public async Task<OkResult> ResetDB()
        {
            await _ctx.Database.EnsureDeletedAsync();
            await _ctx.Database.EnsureCreatedAsync();
            return Ok();
        }
    }
}
