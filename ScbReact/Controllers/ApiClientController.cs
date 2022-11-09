using Microsoft.AspNetCore.Mvc;
using ScbReact.Data;


namespace ScbReact.Controllers

{
    [ApiController]
    [Route("api/fetch")]
    [ApiVersion("0.1")]
    public class ApiClientController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public ApiClientController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [ApiVersion("0.1")]

        [HttpPost]

        public async Task<ActionResult> OnPost()
        {
            return null;
        }

       


    }
}