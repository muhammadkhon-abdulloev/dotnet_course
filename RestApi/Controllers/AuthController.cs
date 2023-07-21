using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController: ControllerBase
{
    public AuthController() { }
    
    [HttpGet]
    [Route("login")]
    [ProducesResponseType(200)]
    public IResult Login()
    {
        Response.Cookies.Append("Authorization", Guid.NewGuid().ToString());
        return Results.Redirect("/");
    }
}