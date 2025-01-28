using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext _context = context;
    
    // Create
    public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
        if (entity == null)
            return null!;

        try
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating the customer entity : {ex.Message}");
            return null!;
        }
    }
    
    // Read
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }
    
    public async Task<CustomerEntity> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return null!;

        return await _context.Customers.FirstOrDefaultAsync(expression) ?? null!;
    }
    
    // Update
    public async Task<CustomerEntity> UpdateAsync(CustomerEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await GetAsync(product => product.Id == updatedEntity.Id);
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating the customer entity : {ex.Message}");
            return null!;
        }
    }
    
    // Delete
    public async Task<bool> DeleteAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        if (expression == null)
            return false;
        
        try
        {
            var existingEntity = await GetAsync(expression);
            if (expression == null)
                return false;

            _context.Customers.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting the customer entity : {ex.Message}");
            return false;
        }
    }
    
    // This is only for checking if something that's about to be added already exists.
    public async Task<bool> AlreadyExistsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        return await _context.Customers.AnyAsync(expression);
    }
}