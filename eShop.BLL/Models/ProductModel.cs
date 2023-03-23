namespace eShop.BLL.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Count { get; set; }
    public List<OrderModel> Orders { get; set; } = new();
}