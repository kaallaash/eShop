using eShop.Core.Entities;

namespace eShop.DAL.Entities;

public class OrderEntity : BaseEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public UserEntity? User { get; set; }
    public ProductEntity? Product { get; set; }
}