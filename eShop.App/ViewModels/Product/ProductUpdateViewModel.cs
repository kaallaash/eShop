using System.ComponentModel.DataAnnotations;

namespace eShop.App.ViewModels.Product;

public class ProductUpdateViewModel
{
    public string? Name { get; set; }
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "The field Price must be greater than 0.")]
    public decimal Price { get; set; }
    public string? Description { get; set; }
    [Range(0, int.MaxValue)]
    public int Count { get; set; }
}