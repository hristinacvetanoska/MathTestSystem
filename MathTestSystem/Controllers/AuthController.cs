using MathTestSystem.Domain.Entities;
using MathTestSystem.DTOs;
using MathTestSystem.Infrasturcture.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly JwtTokenService jwtTokenService;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, JwtTokenService jwtTokenService)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        var user = await this.userManager.FindByNameAsync(loginRequestDTO.Username);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var result = await this.signInManager.CheckPasswordSignInAsync(
            user, loginRequestDTO.Password, false);

        if (!result.Succeeded)
            return Unauthorized("Invalid credentials");

        var roles = await this.userManager.GetRolesAsync(user);
        var token = jwtTokenService.GenerateToken(user, roles);

        return Ok(new
        {
            user.Id,
            user.UserName,
            Roles = roles,
            user.ProfileId,
            Token = token,
        });
    }
}
