using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProductRepository(DataContext context) : IProductRepository
{
    private readonly DataContext _context = context;

    public async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating product entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        if (expression == null)
            return null!;
        
        return await _context.Products.FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<ProductEntity> UpdateAsync(ProductEntity updatedEntity)
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
            Debug.WriteLine($"Error updating product entity :: {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        try
        {
            var existingEntity = await GetAsync(expression);
            if (existingEntity == null)
                return false;
            
            _context.Products.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting product entity :: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        return await _context.Products.AnyAsync(expression);
    }
}