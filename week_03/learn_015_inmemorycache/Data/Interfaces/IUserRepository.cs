using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository
{
    Task AddAsync(UserEntity entity);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate);
}