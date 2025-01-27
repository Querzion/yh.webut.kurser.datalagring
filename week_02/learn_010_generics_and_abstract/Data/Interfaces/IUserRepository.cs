using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository
{
    Task<UserEntity> CreateAsync(UserEntity entity);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> expression);
    Task<UserEntity> UpdateAsync(UserEntity updatedEntity);
    Task<bool> DeleteAsync(Expression<Func<UserEntity, bool>> expression);
    Task<bool> ExistsAsync(Expression<Func<UserEntity, bool>> expression);
}