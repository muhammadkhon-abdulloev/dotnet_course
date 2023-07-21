using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models;

[Index("Id", IsUnique = true, Name = "UserIdIndex")]
public class User
{
    [Column("id"), Key, Required]
    public Guid Id { get; set; }
    [Column("name"), Required]
    public string? Name { get; set; }
    [Column("age"), Required]
    public int Age { get; set; }
}