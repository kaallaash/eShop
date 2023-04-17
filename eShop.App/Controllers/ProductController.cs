using AutoMapper;
using eShop.App.ViewModels.Product;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.App.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);
        return View(_mapper.Map<IEnumerable<ProductViewModel>>(products));
    }
    
    [Authorize]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetByIdAsync(id, cancellationToken);
        return View(_mapper.Map<ProductViewModel>(product));
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateViewModel productCreateViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var product = await _productService.CreateAsync(
            _mapper.Map<ProductModel>(productCreateViewModel), cancellationToken);

        if (product is null)
        {
            return View();
        }

        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetByIdAsync(id, cancellationToken);

        if (product is null) 
        {
            return View("NotFound");
        }

        return View(_mapper.Map<ProductUpdateViewModel>(product));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Edit(
        int id, 
        ProductUpdateViewModel productUpdateViewModel,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(productUpdateViewModel);
        }

        var product = _mapper.Map<ProductModel>(productUpdateViewModel);
        product.Id = id;

        await _productService.UpdateAsync(product, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(id, cancellationToken);

        return View("DeleteCompleted");
    }
}