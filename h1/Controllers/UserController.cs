using h1.Interfaces;
using h1.Models;
using Microsoft.AspNetCore.Mvc;

namespace h1.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController: ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public IResult GetUser()
    {
        var users = _userRepository.GetUsers();
        return Results.Json(users);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IResult GetUser(int id)
    {
        var user = _userRepository.GetUserById(id);
        return user.Result == null ? Results.NotFound("User not found") : Results.Json(user);
    }
    
    [HttpPost]
    public IResult PostUser(User user)
    {
        var isCreated = _userRepository.CreateUser(user);
        
        return isCreated.Result ? Results.NotFound("Error while creating user") : Results.Ok("ok");
    }
    
    [HttpPut]
    public IResult PutUser(User user)
    {
        var newUser = _userRepository.UpdateUser(user);
        return newUser.Result == null ? Results.NotFound("User not found") : Results.Json(newUser);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public IResult DeleteUser(int id)
    {
        var user = _userRepository.DeleteUser(id);
    
        return user.Result == null ? Results.BadRequest("Can not delete object"): Results.Ok(user);
    }
}