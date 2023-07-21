using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RestApi.Helper;
using RestApi.Models;

namespace RestApi.Data;

public sealed class ApplicationContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.Id).IsUnique().HasDatabaseName("UserIdIndex");
            e.Property(u => u.Id).HasColumnName("id").IsRequired().HasDefaultValue(Guid.NewGuid());
            e.Property(u => u.Name).HasColumnName("name").IsRequired();
            e.Property(u => u.Age).HasColumnName("age").IsRequired();
            e.HasData(
                new User { Id = Guid.NewGuid(), Name = "Tom", Age = 37 },
                new User { Id = Guid.NewGuid(), Name = "Bob", Age = 41 },
                new User { Id = Guid.NewGuid(), Name = "Sam", Age = 24 }
            );
        });

        modelBuilder.Entity<Admin>(e =>
        {
            e.HasIndex(a => a.Id).IsUnique().HasDatabaseName("AdminIdIndex");
            e.Property(a => a.Id).HasColumnName("id").IsRequired();
            e.Property(a => a.Username).HasColumnName("username").IsRequired();
            e.Property(a => a.PasswordHash).HasColumnName("password_hash").IsRequired();
            e.HasData(
                new Admin { Id = 1, Username = "test_admin", PasswordHash = PasswordHasher.HashPassword("test_pass")}
            );
        });
    }
}