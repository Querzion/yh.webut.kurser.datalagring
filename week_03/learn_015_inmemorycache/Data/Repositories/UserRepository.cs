using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public async Task AddAsync(UserEntity entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        var entities = await _context.Users.ToListAsync();
        return entities;
    }

    public async Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(predicate);
        return entity;
    }
}