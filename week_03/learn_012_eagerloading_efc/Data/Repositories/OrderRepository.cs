using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OrderRepository(DataContext context) : BaseRepository<OrderEntity>(context), IOrderRepository
{
    public async Task<OrderEntity?> GetWithOrderDetailsAsync(int orderId)
    {
        return await _dbSet
            .Include(order => order.OrderRows)
            .ThenInclude(orderRows => orderRows.Unit)
            .FirstOrDefaultAsync(x => x.Id == orderId);
    }
}