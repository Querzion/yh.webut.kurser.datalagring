using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OrderRepository(DataContext context) : IOrderRepository
{
    private readonly DataContext _context = context;
    
    public async Task<IEnumerable<OrderEntity>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<OrderEntity?> GetAsync(int id)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }
}