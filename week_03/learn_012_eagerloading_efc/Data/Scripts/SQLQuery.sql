-- SQL Script
-- Created on 29/01/2025 by querzion

-- Write your SQL queries below:
SELECT
    Orders.Id AS OrderId,
    Orders.CustomerName,
    FORMAT (Orders.OrderDate, 'yyyy-MM-dd') AS OrderDate,
    FORMAT (Orders.DueDate, 'yyyy-MM-dd') AS DueDate,
    OrderRows.Description,
    OrderRows.Quantity,
    Units.Unit,
    OrderRows.Price,
    OrderRows.Discount
FROM Orders;

JOIN OrderRows ON Orders.Id = OrderRows.OrderId
JOIN Units ON OrderRows.UnitId = Units.Id
