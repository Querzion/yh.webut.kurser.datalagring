using Data.Entities;

namespace Business.Interfaces;

public interface IOrderService
{
    // This should read out from Order and not OrderEntity!
    Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
    Task<OrderEntity?> GetOrderByIdAsync(int orderId);
}