using Infrastructure.Models;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerEntity entity);
    Task<bool> DeleteAsync(CustomerEntity entity);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task<bool> UpdateAsync(CustomerEntity entity);
}