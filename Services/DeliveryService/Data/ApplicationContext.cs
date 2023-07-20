using Delivery.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data;

public sealed class ApplicationContext: DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(etp =>
        {
            etp.HasIndex(o => o.Id).IsUnique().HasDatabaseName("OrderIdIndex");
            etp.Property(o => o.Id).HasColumnName("id").IsRequired();
            etp.Property(o => o.SenderCity).HasColumnName("sender_city").IsRequired();
            etp.Property(o => o.SenderAddress).HasColumnName("sender_address").IsRequired();
            etp.Property(o => o.ReceiverCity).HasColumnName("receiver_city").IsRequired();
            etp.Property(o => o.ReceiverAddress).HasColumnName("receiver_address").IsRequired();
            etp.Property(o => o.CargoWeight).HasColumnName("cargo_weight").IsRequired().HasColumnType("numeric");
            etp.Property(o => o.PickupDate).HasColumnName("pickup_date").IsRequired();

            etp.HasData(
                new Order
                {
                    Id = 1,
                    SenderCity = "Khujand",
                    SenderAddress = "Raheem Jalil, 12",
                    ReceiverCity = "Moscow",
                    ReceiverAddress = "Malaya Ordynka, 9",
                    CargoWeight = 1.35,
                    PickupDate = DateOnly.FromDateTime(DateTime.Now.Add(TimeSpan.FromDays(3)))
                });
        });
    }
}