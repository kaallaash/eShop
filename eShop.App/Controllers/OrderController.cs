using AutoMapper;
using eShop.App.ViewModels.Order;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace eShop.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<OrderViewModel>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await _orderService.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
    }

    [HttpGet("{id}")]
    public async Task<OrderModel?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _orderService.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public async Task<OrderViewModel> Create(
        [FromBody] OrderCreateViewModel orderCreateViewModel,
        CancellationToken cancellationToken)
    {
        var order = await _orderService.CreateAsync(_mapper.Map<OrderModel>(orderCreateViewModel), cancellationToken);

        return _mapper.Map<OrderViewModel>(order);
    }

    [HttpPut("{id}")]
    public async Task<OrderViewModel> Update(int id,
        [FromBody] OrderUpdateViewModel orderUpdateViewModel,
        CancellationToken cancellationToken)
    {
        var orderModel = _mapper.Map<OrderModel>(orderUpdateViewModel);
        orderModel.Id = id;

        var actualOrder = await _orderService.UpdateAsync(orderModel, cancellationToken);

        return _mapper.Map<OrderViewModel>(actualOrder);
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        return await _orderService.DeleteAsync(id, cancellationToken);
    }
}