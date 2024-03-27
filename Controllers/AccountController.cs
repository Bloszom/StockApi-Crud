using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using morningclassonapi.DTO.Account;
using morningclassonapi.Interfaces;
using morningclassonapi.Model;

namespace morningclassonapi.Controllers
{
    
    [Route("api/[controller]")]//routes
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        [HttpPost("register")]
        //when registering,d first thing to do is to check is model state is valid
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var appuser = new AppUser
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Username
                };

                var createuser = await _userManager.CreateAsync(appuser, registerDto.Password);
                if (createuser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appuser, "User");
                   if (roleResult.Succeeded)
                   {
                       return Ok(
                           new NewUserDto
                           {
                                UserName = appuser.UserName,
                                Email = appuser.Email,
                                Token = _tokenService.CreateToken(appuser)
                           }
                       );
                   }
                   else
                   {
                       return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createuser.Errors);
                    
                }

            }
            catch(Exception e){

                //return is used to  attatch status code;
                return StatusCode(500, e);
                //while throw is used to just return e;
               
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if user is valid
            var user = await _userManager.Users.FirstOrDefaultAsync(au => au.UserName == loginDto.UserName);

            if (user == null) 
                return Unauthorized("invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Username/password incorrect");

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            });

        }

     

    }
}
