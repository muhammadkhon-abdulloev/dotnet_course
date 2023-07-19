using System.ComponentModel.DataAnnotations;

namespace h1.Dto;

public class UserDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    
    public int Age { get; set; }
}