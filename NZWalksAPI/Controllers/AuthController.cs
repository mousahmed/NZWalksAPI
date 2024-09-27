using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionsFilters;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }
        [HttpPost("register")]
        [ValidateModelAttributes]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {

                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login.");
                }

            }
            // Give an Error
            identityResult.Errors.ToList().ForEach(error => ModelState.AddModelError("Errors", error.Description));
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        [ValidateModelAttributes]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token

                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
