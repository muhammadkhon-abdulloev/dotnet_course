using h1.Dto;

namespace h1.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}