using AutoMapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.BLL.Services;

public class OrderService : GenericServiceAsync<OrderModel, OrderEntity>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper) : base(orderRepository, mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
}