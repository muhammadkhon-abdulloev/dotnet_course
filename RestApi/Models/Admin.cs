using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models;

[Index("Id", IsUnique = true, Name = "UserIdIndex")]
public class Admin
{
    [Column("id"), Key] 
    public required int Id { get; set; }
    
    [Column("name")]
    public required string Username { get; set; }
    
    [Column("password_hash")]   
    public required string PasswordHash { get; set; }
    
}