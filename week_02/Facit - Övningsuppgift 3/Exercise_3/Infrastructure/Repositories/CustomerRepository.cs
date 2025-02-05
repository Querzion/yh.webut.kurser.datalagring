using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext _context = context;


    // CREATE
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


    // READ
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var entities = await _context.Customers.ToListAsync();
        return entities;
    }

    public async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(expression);
        return entity;
    }


    // UPDATE
    public async Task<bool> UpdateAsync(CustomerEntity entity)
    {
        try
        {
            var existingEntity = await _context.Customers.FindAsync(entity.Id);
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


    // DELETE
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
