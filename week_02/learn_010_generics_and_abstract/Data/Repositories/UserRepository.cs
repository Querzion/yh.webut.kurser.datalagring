using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public async Task<UserEntity> CreateAsync(UserEntity entity)
    {
        if (entity == null)
            return null!;
        
        try
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating user entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        
        return await _context.Users.FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;
        
        try
        {
            var existingEntity = await GetAsync(x => x.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;
            
            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating user entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<UserEntity, bool>> expression)
    {
        if (expression == null)
            return false;
        
        try
        {
            var existingEntity = await GetAsync(expression);
            if (existingEntity == null)
                return false;
            
            _context.Users.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating user entity :: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ExistsAsync(Expression<Func<UserEntity, bool>> expression)
    {
        return await _context.Users.AnyAsync(expression);
    }
}