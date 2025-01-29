using Data.Entities;

namespace Data.Interfaces;

public interface IOrderRepository : IBaseRepository<OrderEntity>
{
    Task<OrderEntity?> GetWithOrderDetailsAsync(int orderId);
}