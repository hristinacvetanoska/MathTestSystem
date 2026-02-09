namespace MathTestSystem.Controllers
{
    using MathTestSystem.DTOs;
    using MathTestSystem.Infrasturcture.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AuthController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDTO request)
        {
            var user = _context.Users
                .FirstOrDefault(u =>
                    u.Username == request.Username &&
                    u.Password == request.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(new UserDTO
            {
                Id = user.ProfileId,
                Username = user.Username,
                Role = user.Role.ToString()
            });
        }
    }
}
