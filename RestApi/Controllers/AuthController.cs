using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestApi.Dto;

namespace RestApi.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController: ControllerBase
{
    private readonly SymmetricSecurityKey _secretKey;
    public AuthController(IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("SecretKey").Value;
        _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
    }
    
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(200), ProducesResponseType(400)]
    public IResult Login(UserDto userDto)
    {
        
        if (userDto.Name == null)
        {
            return Results.BadRequest("invalid username");
        }

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, userDto.Name) };
        var jwt = new JwtSecurityToken(
            issuer: "ISSUER",
            audience: "AUDIENCE",
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256));
            var token =  new JwtSecurityTokenHandler().WriteToken(jwt);
            
        return Results.Ok(token);
    }
}