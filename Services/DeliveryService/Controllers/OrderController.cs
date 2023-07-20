using AutoMapper;
using Delivery.Dto;
using Delivery.Models;
using Delivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/order")]
[ApiVersion("1.0")]
public class OrderController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    public OrderController(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> CreateOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        var orderId = await _orderRepository.CreateOrder(order);

        var response = new DefaultResponseDto
        {
            Ok = true, 
            Comment = "Order created successfully", 
            OrderId = orderId
        };
        return Results.Json(response, statusCode:StatusCodes.Status201Created);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> GetOrders()
    {
        var orders = await _orderRepository.GetOrders();

        return orders.Count < 1
            ? Results.Json(
                new DefaultResponseDto { Comment = "No orders yet ;(" },
                statusCode: StatusCodes.Status204NoContent)
            : Results.Json(orders, statusCode: StatusCodes.Status200OK);
    }
    
    [HttpGet("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> GetOrders(int orderId)
    {
        var order = await _orderRepository.GetOrderById(orderId);

        return order == null
            ? Results.Json(
                new DefaultResponseDto { Comment = "Invalid orderId" },
                statusCode: StatusCodes.Status400BadRequest)
            : Results.Json(order, statusCode: StatusCodes.Status200OK);
    }
}