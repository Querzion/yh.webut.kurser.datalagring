using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    
    public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
    {
        // This ONLY shows the OrderEntity!
        // return await _orderRepository.GetAllAsync();
        // So in order to gain access to more information, we'll have to make a query,
        // and this one will include both the Order, OrderRows and Unit Entities.
        return await _orderRepository.GetAllAsync(query =>
            query.Include(order => order.OrderRows)
                 .ThenInclude(orderRows => orderRows.Unit)
        );
    }

    public async Task<OrderEntity?> GetOrderByIdAsync(int orderId)
    {
        // var result = await _orderRepository.GetAsync(x => x.Id == orderId);
        
        // var result = await _orderRepository.GetAsync(x => x.Id == orderId, query =>
        //     query.Include(order => order.OrderRows)
        //          .ThenInclude(orderRows => orderRows.Unit)
        // );
        
        return await _orderRepository.GetWithOrderDetailsAsync(orderId);
    }
}