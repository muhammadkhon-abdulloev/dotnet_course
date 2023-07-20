using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data;

public sealed class ApplicationContext: DbContext
{
    public DbSet<Url> Urls { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Url>().HasData(
            new Url{LongUrl = "https://google.com", ShortUrl = "0"}
            );
    }
}