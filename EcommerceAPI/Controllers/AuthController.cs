using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.Password
            );

            if (user is null)
                return BadRequest("An account with that email already exists.");

            var token = _authService.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName
                }
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _authService.LoginAsync(dto.Email, dto.Password);

            if (user is null)
                return Unauthorized("Invalid email or password.");

            var token = _authService.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName
                }
            });
        }
    }

    public record RegisterDto(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );

    public record LoginDto(
        string Email,
        string Password
    );
}