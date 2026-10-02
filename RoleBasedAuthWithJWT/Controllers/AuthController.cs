using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthWithJWT.Data;
using RoleBasedAuthWithJWT.Jwt;
using RoleBasedAuthWithJWT.DTO;
using BCrypt.Net;

namespace RoleBasedAuthWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IJwtService _jwtService;
        public AuthController(AppDbContext context,IJwtService jwtService)
        {
            _appDbContext = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _appDbContext.Users.Include(us => us.UserRoles).ThenInclude(ur => ur.Role)
                .FirstOrDefault(us => us.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return Unauthorized("Invalid Username or Password");
            }
            var roles = user.UserRoles.Select(us => us.Role.Name).ToList();
            var token = _jwtService.GenerateJwtToken(user, roles);
            return Ok(new { Token = token });

        }
    }
}
