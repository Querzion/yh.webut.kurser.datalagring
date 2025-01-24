using Business.Dtos;
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class ProductService(DataContext context, ICategoryService categoryService) : IProductService
{
    private readonly DataContext _context = context;
    private readonly ICategoryService _categoryService = categoryService;

    public ProductEntity CreateProduct(ProductRegistrationForm form)
    {
        var categoryEntity = _categoryService.CreateCategory(form.CategoryName);
        
        var productEntity = new ProductEntity
        {
            Name = form.Name,
            Price = form.Price,
            Category = categoryEntity,
        };
        
        _context.Products.Add(productEntity);
        _context.SaveChanges();
        
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        var products = _context.Products.Include(x => x.Category).ToList();
        return products;
    }
}