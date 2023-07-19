using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestApi.Constants;
using RestApi.Dto;
using RestApi.Helper;
using RestApi.Interfaces;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace RestApi.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController: ControllerBase
{
    private readonly SymmetricSecurityKey _secretKey;
    private readonly IAdminRepository _adminRepository;
    public AuthController(
        IConfiguration configuration, 
        IAdminRepository adminRepository
        )
    {
        var secretKey = configuration.GetSection("SecretKey").Value;
        _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        _adminRepository = adminRepository;
    }
    
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponseDto))] 
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponseDto))]
    public IResult Login(AdminDto adminDto)
    {
        
        if (adminDto.Username == "" || adminDto.Password == "")
        {
            return Results.Json(
                new DefaultResponseDto{Comment = Responses.InvalidUserNameOrPassword}, 
                statusCode:StatusCodes.Status400BadRequest);
        }

        var admin = _adminRepository.GetAdminByUsername(adminDto.Username).Result;
        if (admin == null)
        {
            return Results.Json(
                new DefaultResponseDto {Comment = Responses.InvalidUserNameOrPassword}, 
                statusCode:StatusCodes.Status400BadRequest);
        }
        
        if (!PasswordHasher.CompareHashAndPassword(admin.PasswordHash, adminDto.Password))
            return Results.Json(
                new DefaultResponseDto {Comment = Responses.InvalidUserNameOrPassword}, 
                statusCode:StatusCodes.Status400BadRequest);
        
        var claims = new List<Claim> { new(ClaimTypes.Name, adminDto.Username) };
        var jwt = new JwtSecurityToken(
            issuer: "ISSUER",
            audience: "AUDIENCE",
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256));
            var token =  new JwtSecurityTokenHandler().WriteToken(jwt);
            
        return Results.Json(
            new DefaultResponseDto{Ok = true, Data = token},
            statusCode: StatusCodes.Status200OK);
    }
}