using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RestApi.Helper;
using RestApi.Models;

namespace RestApi.Data;

public sealed class ApplicationContext: DbContext
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Admin> Admin { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Name = "Tom", Age = 37 },
            new User { Id = Guid.NewGuid(), Name = "Bob", Age = 41 },
            new User { Id = Guid.NewGuid(), Name = "Sam", Age = 24 }
        );
        modelBuilder.Entity<Admin>().HasData(
            new Admin { Id = 1, Username = "test_admin", PasswordHash = PasswordHasher.HashPassword("test_pass")}
        );
    }
}