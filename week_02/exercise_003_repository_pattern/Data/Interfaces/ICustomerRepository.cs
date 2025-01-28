using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface ICustomerRepository
{
    // Create
    Task<CustomerEntity> CreateAsync(CustomerEntity entity);
    
    // Read
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity> GetAsync(Expression<Func<CustomerEntity, bool>> expression);
    
    // Update
    Task<CustomerEntity> UpdateAsync(CustomerEntity updatedEntity);
    
    // Delete
    Task<bool> DeleteAsync(Expression<Func<CustomerEntity, bool>> expression);
    
    // (Extras) Check
    Task<bool> AlreadyExistsAsync(Expression<Func<CustomerEntity, bool>> expression);
}