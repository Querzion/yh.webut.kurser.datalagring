using Business.Dtos;
using Business.Models;
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

    public IEnumerable<Product> GetAllProducts()
    {
        var products = new List<Product>();
        
        var entities = _context.Products.Include(x => x.Category).ToList();
        entities.ForEach(p => products.Add(new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryName = p.Category.Name,
        }));
         
        return products;
    }
}