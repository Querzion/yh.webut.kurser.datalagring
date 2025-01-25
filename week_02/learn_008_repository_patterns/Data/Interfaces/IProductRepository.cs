using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IProductRepository
{
    Task<ProductEntity> CreateAsync(ProductEntity entity);
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    
    // The Expression Functionality gives you a broader opportunity for searching after something,
    // if it's by Id, Name, Email or which ever database/entity/model/dto config that's been added.
    // var product = await GetAsync(x => x.Id == id)
    // var product = await GetAsync(x => x.Name == id)
    // var product = await GetAsync(x => x.Email == id)
    // var product = await GetAsync(x => x.Address == id)
    // etc. with this async method.
    Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<ProductEntity> UpdateAsync(ProductEntity updatedEntity);
    Task<bool> DeleteAsync(Expression<Func<ProductEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression);
}