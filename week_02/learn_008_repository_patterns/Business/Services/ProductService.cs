using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Product> CreateProductAsync(ProductRegistrationForm form)
    {
        // Check if a product already exists
        var entity = await _productRepository.GetAsync(x => x.Name == form.Name);
        entity ??= await _productRepository.CreateAsync(ProductFactory.Create(form));
        
        return ProductFactory.Create(entity);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var entities = await _productRepository.GetAllAsync();
        var products = entities.Select(ProductFactory.Create);
        return products;
    }
    
    // Get by Id
    // public async Task<Product> GetProductByIdAsync(int id)
    // {
    //     var entity = await _productRepository.GetAsync(x => x.Id == id);
    //     var product = ProductFactory.Create(entity);
    //     return product ?? null!;
    // }
    
    // Get by Name
    // public async Task<Product> GetProductByNameAsync(string name)
    // {
    //     var entity = await _productRepository.GetAsync(x => x.Name == name);
    //     var product = ProductFactory.Create(entity);
    //     return product ?? null!;
    // }
    
    // Get by any variable, be it Id, Name whatever.
    public async Task<Product> GetProductAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = await _productRepository.GetAsync(expression);
        var product = ProductFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<Product> UpdateProductAsync(ProductUpdateForm form)
    {
        var entity = await _productRepository.UpdateAsync(ProductFactory.Create(form));
        var product = ProductFactory.Create(entity);
        return product ?? null!;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}