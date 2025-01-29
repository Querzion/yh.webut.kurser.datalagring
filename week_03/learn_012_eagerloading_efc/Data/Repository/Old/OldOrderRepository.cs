// using Data.Contexts;
// using Data.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace Data.Repository;

// public class OrderRepository(DataContext context)
// {
//     private readonly DataContext _context = context;
//
//     public async Task<IEnumerable<OrderEntity>> GetAllAsync()
//     {
        // LinkQuery below here gets specific values, much simular to this SQL example code
        // -----
        // SELECT
        //      Orders.CustomerName,
        //      Orders.OrderDate,
        //      Units.Unit,
        //      OrderRows.Price
        // FROM Orders
        // JOIN OrderRows ON Orders.Id = OrderRows.OrderId
        // JOIN Units ON OrderRows.UnitId = Units.Id
        // ----- Basically does the same thing.
        // var result = await
        // (
        //     from order in _context.Orders
        //     join orderRow in _context.OrderRows on order.Id equals orderRow.OrderId
        //     join unit in _context.Units on orderRow.UnitId equals unit.Id
        //     select new
        //     {
        //         CustomerName = order.CustomerName,
        //         OrderDate = order.OrderDate,
        //         Unit = unit.Unit,
        //         Price = orderRow.Price,
        //     }
        // ).ToListAsync();
        
        // Database Query that gets all values. In this, We start of from the OrderEntity,
        // Where we include OrderRowsEntity, and Then we include the UnitID in so that we can Then Include
        // the Unit Value from the UnitEntity.
        // return await _context.Orders
        //     .Include(orders => orders.OrderRows)
        //     .ThenInclude(orderRows => orderRows.Unit)
        //     .ThenInclude(unit => unit.Unit)
        //     .ToListAsync();
//     }
// }