using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class OrderStatusRepository(DataContext context) : BaseRepository<OrderStatusEntity>(context)
{
    
}