using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Models;
using MovieApi.Repositers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepositery _tokenRepositery;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositery tokenRepositery)
        {
           
            _userManager = userManager;
            _tokenRepositery = tokenRepositery;
        }



        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]Register register)
        {
            var identityuser = new IdentityUser

            {
                UserName = register.Email,
                Email = register.Email,
                PhoneNumber = register.Mobile.ToString()

            };
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(identityuser, register.Password);

                if (result.Succeeded)
                {

                    return Ok("User Registered");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return BadRequest("SomeThing Wrong");

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromForm]User user)
        {
            // Check if user is authenticated
            // Check username and password
            var userdata = await _userManager.FindByEmailAsync(user.Email);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(userdata);
                var jwttoken = _tokenRepositery.CreatedJWTToken(userdata);
                return Ok(jwttoken);
            }

            return BadRequest("Username or Password is incorrect.");
        }


    }
}
