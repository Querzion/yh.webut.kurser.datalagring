using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Services;

public interface IProductService
{
    ProductEntity CreateProduct(ProductRegistrationForm form);
    IEnumerable<Product> GetAllProducts();
}