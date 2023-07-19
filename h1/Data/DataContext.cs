using h1.Models;
using Microsoft.EntityFrameworkCore;

namespace h1.Data;

public class DataContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
         Database.EnsureCreatedAsync();
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