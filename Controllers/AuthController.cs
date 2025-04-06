using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }


    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUp signUpObj){
        var checkUser = await _userManager.FindByEmailAsync(signUpObj.Email);

        if(checkUser != null) return BadRequest("Email Already Exist");

        var user = new User{
            UserName = signUpObj.Email,
            Email = signUpObj.Email
        };

        var result = await _userManager.CreateAsync(user, signUpObj.Password);
        if(result.Succeeded){
            if(!await _roleManager.RoleExistsAsync("User")) await _roleManager.CreateAsync(new IdentityRole("User"));

            await _userManager.AddToRoleAsync(user, "User");
            return Ok(user);
        }
        else return BadRequest(new {errors = result.Errors.Select(e => e.Description)});
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignIn signInObj){
        var user = await _userManager.FindByEmailAsync(signInObj.Email);

        if(user != null && await _userManager.CheckPasswordAsync(user, signInObj.Password)){
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, roles[0]),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = GenerateJwtToken(claims);
            return Ok(token);
        }
        else return BadRequest("Invalid Email or Password");
    }


    [Authorize(Roles = "User")]
    [HttpGet("Authorized")]
    public IActionResult Authorized(){
        return Ok("You are authorized");
    }
    private string GenerateJwtToken(List<Claim> authClaims){
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: DateTime.Now.AddDays(2),
            claims: authClaims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
