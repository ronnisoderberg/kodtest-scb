using GeoComment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;





namespace GeoComment.Controllers
{
    [ApiController]
    [Route("")]


    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _UserManager;

        public UserController(UserManager<User> userManager)
        {
            _UserManager = userManager;
        }


        public class NewUser
        {
            public String Username { get; set; }
            public String Password { get; set; }
        }

        //[HttpPost]
        //public async Task<IActionResult> RegUser();

    }
}