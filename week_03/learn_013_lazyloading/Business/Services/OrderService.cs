using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    
    public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<OrderEntity?> GetOrderByIdAsync(int orderId)
    {
        return await _orderRepository.GetAsync(orderId);
    }
}