using AutoMapper;
using Delivery.Dto;
using Delivery.Interfaces;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/order")]
[ApiVersion("1.0")]
public class OrderController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;
    public OrderController(
        IOrderService orderService,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderService = orderService;
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> CreateOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        var orderId =  await _orderService.CreateOrder(order);

        var response = new DefaultResponseDto
        {
            Ok = true, 
            Comment = "Order created successfully", 
            OrderId = orderId
        };
        return Results.Json(response, statusCode:StatusCodes.Status201Created);
    }
    
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> GetOrders()
    {
        var orders = await _orderService.GetOrders();

        return orders.Count < 1
            ? Results.Json(
                new DefaultResponseDto
                {
                    Comment = "No orders yet ;("
                },
                statusCode: StatusCodes.Status404NotFound)
            : Results.Json(orders, statusCode: StatusCodes.Status200OK);
    }
    
    [HttpGet("{orderId:int}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponseDto))]
    public async Task<IResult> GetOrders(int orderId)
    {
        var order = await _orderService.GetOrderById(orderId);

        return order == null
            ? Results.Json(
                new DefaultResponseDto
                {
                    Comment = "Invalid orderId", 
                    OrderId = orderId
                },
                statusCode: StatusCodes.Status400BadRequest)
            : Results.Json(order, statusCode: StatusCodes.Status200OK);
    }
}