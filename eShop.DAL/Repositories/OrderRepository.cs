using eShop.DAL.Context;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.DAL.Repositories;

public class OrderRepository : GenericRepositoryAsync<OrderEntity>, IOrderRepository
{
    public OrderRepository(DatabaseContext context) : base(context) { }
}