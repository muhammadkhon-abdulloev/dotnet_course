using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Constants;
using RestApi.Dto;
using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Controllers;

[Authorize]
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<UserDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DefaultResponseDto))]
    public IResult GetUsers()
    {
        var users = _userRepository.GetUsers();
        var usersDto = _mapper.Map<ICollection<UserDto>>(users);
        
        return usersDto.Count < 1 ? Results.Json(
            new DefaultResponseDto{Comment = Responses.NoContent}, 
            statusCode: StatusCodes.Status204NoContent) : Results.Ok(usersDto);
    }
    
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DefaultResponseDto))]
    public IResult GetUser(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        var userDto = _mapper.Map<UserDto>(user.Result);
        
        return user.Result == null ? Results.Json(
            new DefaultResponseDto{Comment = Responses.UserNotFound}, 
            statusCode: StatusCodes.Status404NotFound) : Results.Json(userDto);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponseDto))]
    public IResult PostUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var isCreated = _userRepository.CreateUser(user);
        
        return !isCreated.Result ? Results.Json(
            new DefaultResponseDto{Comment = Responses.BadRequest}, 
            statusCode: StatusCodes.Status404NotFound) : Results.Created(HttpContext.Request.Path.ToString(), user);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DefaultResponseDto))]
    public IResult PutUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var newUser = _userRepository.UpdateUser(user);
        
        return newUser.Result == null ? Results.Json(
            new DefaultResponseDto{Comment = Responses.UserNotFound}, 
            statusCode: StatusCodes.Status404NotFound) : Results.Ok(newUser.Result);
    }
    
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DefaultResponseDto))]
    public IResult DeleteUser(Guid id)
    {
        var user = _userRepository.DeleteUser(id).Result;
        if (user == null)
        {
            return Results.Json(
                new DefaultResponseDto{Comment = Responses.UserNotFound}, 
                statusCode: StatusCodes.Status404NotFound);
        }
        
        var userDto = _mapper.Map<UserDto>(user);
        return Results.Ok(userDto);
    }
}