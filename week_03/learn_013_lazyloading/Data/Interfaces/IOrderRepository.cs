using Data.Entities;

namespace Data.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllAsync();
    Task<OrderEntity?> GetAsync(int id);
    
}