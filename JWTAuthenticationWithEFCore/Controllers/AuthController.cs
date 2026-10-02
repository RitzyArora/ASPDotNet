using Microsoft.AspNetCore.Mvc;
using JWTAuthenticationWithEFCore.Services;
using Microsoft.AspNetCore.Identity.Data;
//using JWTAuthenticationWithEFCore.Models
using System.Threading.Tasks;
namespace JWTAuthenticationWithEFCore.Controllers
{
    
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            var success = await _authService.Register(request.Email, request.Password, "User"); // Default Role: User
            if (!success) return BadRequest(new { message = "User already exists!" });

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Email, request.Password);
            if (token == null) return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { Token = token });
        }
    }

}
