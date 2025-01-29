-- SQL Script
-- Created on 29/01/2025 by querzion

-- Write your SQL queries below:
INSERT INTO Units (Unit)
VALUES ('stk'),('pkt'),('tim'),('dagar');

INSERT INTO Orders (CustomerName, OrderDate, DueDate)
VALUES ('Slisk Lindqvist', '2000-01-01', '2000-01-31');

INSERT INTO OrderRows (Id, OrderId, Description, Quantity, UnitId, Price, Discount)
VALUES (1, 1, 'Thrustmaster T300RS GT Wheeel & Pedals ', 1, 1, 4999, 0),
       (2, 1, 'Thrustmaster Sparco Handbreak', 2, 1, 2499, 0),
       (3, 1, 'Thrustmaster T8H Shifter', 1, 1, 1899, 300);

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
FROM Orders

         JOIN OrderRows ON Orders.Id = OrderRows.OrderId
         JOIN Units ON OrderRows.UnitId = Units.Id

