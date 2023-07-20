using AutoMapper;
using h1.Dto;
using h1.Interfaces;
using h1.Models;
using Microsoft.AspNetCore.Mvc;

namespace h1.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController: ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<UserDto>))]
    [ProducesResponseType(204)]
    public IResult GetUser()
    {
        var users = _userRepository.GetUsers();
        var usersDto = _mapper.Map<ICollection<UserDto>>(users);
        
        return usersDto.Count < 1 ? Results.NoContent() : Results.Ok(usersDto);
    }
    
    [HttpGet("{id:Guid}")]
    public IResult GetUser(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        var userDto = _mapper.Map<UserDto>(user.Result);
        
        return user.Result == null ? Results.NotFound("User not found") : Results.Json(userDto);
    }
    
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    [ProducesResponseType(404)]
    public IResult PostUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var isCreated = _userRepository.CreateUser(user);
        
        return !isCreated.Result ? Results.BadRequest("Error while creating user") : Results.Created(HttpContext.Request.Path.ToString(), "");
    }
    
    [HttpPut]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    [ProducesResponseType(404)]
    public IResult PutUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var newUser = _userRepository.UpdateUser(user);
        
        return newUser.Result == null ? Results.NotFound("User not found") : Results.Ok(newUser.Result);
    }
    
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    [ProducesResponseType(404)]
    public IResult DeleteUser(Guid id)
    {
        var user = _userRepository.DeleteUser(id);
        if (user.Result == null)
        {
            return Results.NotFound("User not found");
        }
        
        var userDto = _mapper.Map<UserDto>(user.Result);
        return Results.Ok(userDto);
    }
}