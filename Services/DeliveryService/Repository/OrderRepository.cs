using Delivery.Data;
using Delivery.Interfaces;
using Delivery.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Repository;

public class OrderRepository: IOrderRepository
{
    private readonly ApplicationContext _db;

    public OrderRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<int> CreateOrder(Order order)
    {
        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
        
        return order.Id;
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _db.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrderById(int id)
    {
        return await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }
}