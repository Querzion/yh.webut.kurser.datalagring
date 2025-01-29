using System.Diagnostics;
using System.Linq.Expressions;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext _context = context;

    // Create
    public async Task<bool> CreateAsync(CustomerEntity entity)
    {
        try
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Read
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var entities = await _context.Customer.ToListAsync();
        return entities;
    }

    public async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _context.Customer.FirstOrDefaultAsync(expression);
        return entity;
    }

    // Update
    public async Task<bool> UpdateAsync(CustomerEntity entity)
    {
        try
        {
            var existingEntity = await _context.Customer.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    
    // Delete
    public async Task<bool> DeleteAsync(CustomerEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}