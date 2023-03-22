using eShop.Core.Interfaces;
using eShop.DAL.Entities;

namespace eShop.DAL.Interfaces.Repositories;

public interface IOrderRepository : IGenericRepositoryAsync<OrderEntity>
{
}