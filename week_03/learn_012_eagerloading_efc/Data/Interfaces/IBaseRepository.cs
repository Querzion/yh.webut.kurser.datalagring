using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    // Send List to get a List that might be based on an expression or not.
    Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null);
    // Order => Order.Id == id (True or False Statement based on an Entities Variables) with the capability to ask for a list, it's default is null.
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null);
}