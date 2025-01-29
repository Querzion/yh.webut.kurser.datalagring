using Data.Entities;

namespace Business.Interfaces;

public interface IOrderService
{
    
    Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
    Task<OrderEntity?> GetOrderByIdAsync(int orderId);
}