namespace eShop.BLL.Models;

public class OrderModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public UserModel? User { get; set; }
    public ProductModel? Product { get; set; }
}