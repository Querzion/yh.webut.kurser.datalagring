using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IProductRepository
{
    Task<ProductEntity> CreateAsync(ProductEntity entity);
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<ProductEntity> UpdateAsync(ProductEntity updatedEntity);
    Task<bool> DeleteAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression);
}