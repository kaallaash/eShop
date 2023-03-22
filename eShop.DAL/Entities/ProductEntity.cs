using eShop.Core.Entities;

namespace eShop.DAL.Entities;

public class ProductEntity : BaseEntity
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Count { get; set; }
    public List<OrderEntity> Orders { get; set; } = new();
}