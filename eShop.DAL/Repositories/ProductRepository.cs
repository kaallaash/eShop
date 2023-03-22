using eShop.DAL.Context;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.DAL.Repositories;

public class ProductRepository : GenericRepositoryAsync<ProductEntity>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context) { }
}