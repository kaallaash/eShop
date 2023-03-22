using AutoMapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.BLL.Services;

public class ProductService : GenericServiceAsync<ProductModel, ProductEntity>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
}