using Delivery.Models;

namespace Delivery.Interfaces;

public interface IOrderService
{
    Task<int> CreateOrder(Order order);
    Task<List<Order>> GetOrders();
    Task<Order?> GetOrderById(int id);

}