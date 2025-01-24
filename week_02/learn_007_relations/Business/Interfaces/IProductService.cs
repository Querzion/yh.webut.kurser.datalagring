using Business.Dtos;
using Data.Entities;

namespace Business.Services;

public interface IProductService
{
    ProductEntity CreateProduct(ProductRegistrationForm form);
    IEnumerable<ProductEntity> GetAllProducts();
}