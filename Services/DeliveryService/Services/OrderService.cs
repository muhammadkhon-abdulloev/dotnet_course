using Delivery.Interfaces;
using Delivery.Models;

namespace Delivery.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;

    }

    public async Task<int> CreateOrder(Order order)
    {
        return await _orderRepository.CreateOrder(order);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _orderRepository.GetOrders();
    }

    public async Task<Order?> GetOrderById(int id)
    {
        return await _orderRepository.GetOrderById(id);
    }
}