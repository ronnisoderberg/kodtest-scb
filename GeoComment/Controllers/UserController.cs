using GeoComment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;





namespace GeoComment.Controllers
{
    [ApiController]
    [Route("/api/user/register")]


    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> OnPost(MakeUser input)
        {
            var user = await _userManager.GetUserAsync(User);

            user = new User()
            {
                UserName= input.Username
            };
            await _userManager.CreateAsync(user, input.Password);

            var regSucces = await  _userManager.CheckPasswordAsync(user, input.Password);

            if (!regSucces)
            {
                return BadRequest();
            }

            var createdUser =
                await _userManager.FindByNameAsync(user.UserName);
           
            return Created("", new 
            {
                username = createdUser.UserName, 
                id = createdUser.Id
            });

        }
    }
}
