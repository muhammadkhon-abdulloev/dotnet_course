using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models;

[Table("user")]
public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}