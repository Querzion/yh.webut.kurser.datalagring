using System.Linq.Expressions;
using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerEntity Entity);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression);
    Task<bool> UpdateAsync(CustomerEntity entity);
    Task<bool> DeleteAsync(CustomerEntity entity);
}