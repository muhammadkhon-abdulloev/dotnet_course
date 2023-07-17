<<<<<<< Updated upstream:h1/Models/User.cs
using h1.Dto;

namespace h1.Models;
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes:RestApi/Dto/UserDto.cs

namespace RestApi.Dto;

public class UserDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    
    public int Age { get; set; }
}