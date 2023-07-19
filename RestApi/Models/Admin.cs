using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models;

[Table("admin")]
public class Admin
{
    public required int Id { get; set; }
    
    public required string Username { get; set; }
    
    public required string PasswordHash { get; set; }
    
}