namespace eShop.App.ViewModels.Product;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Count { get; set; }
}