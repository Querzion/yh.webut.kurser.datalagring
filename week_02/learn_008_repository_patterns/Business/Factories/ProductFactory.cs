using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProductFactory
{
    public static ProductRegistrationForm Create() => new();

    public static ProductEntity Create(ProductRegistrationForm form) => new()
    {
        Name = form.Name,
        Description = form.Description,
        Price = form.Price
    };

    public static Product Create(ProductEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Price = entity.Price
    };
    
    public static ProductUpdateForm Create(Product product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price
    };

    public static ProductEntity Create(ProductUpdateForm form) => new()
    {
        Id = form.Id,
        Name = form.Name,
        Description = form.Description,
        Price = form.Price
    };
}