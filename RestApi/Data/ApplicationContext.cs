using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Data;

public sealed class ApplicationContext: DbContext
{
    public DbSet<User> User { get; set; } = null!;

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
    }
}