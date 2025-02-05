--INSERT INTO Customers VALUES ('ABC Consulting'),('DEF Industries')
--SELECT * FROM Customers

--INSERT INTO CustomerContacts (FirstName, LastName, CustomerId) VALUES ('Anna','Karlsson', 1)
--INSERT INTO CustomerContacts (FirstName, LastName, CustomerId) VALUES ('Bengt','Svensson', 2)

--SELECT 
--	Customers.Id,
--	Customers.CustomerName,
--	CONCAT(CustomerContacts.FirstName, ' ' , CustomerContacts.LastName) AS 'ContactPerson'
--FROM Customers
--JOIN CustomerContacts ON Customers.Id = CustomerContacts.CustomerId

--INSERT INTO Products VALUES ('Konsultid', 1000), ('Utbildning', 5000)
--SELECT * FROM Products

--INSERT INTO Roles VALUES ('Projektledare')
--INSERT INTO Roles VALUES ('Konsult')
--SELECT * FROM Roles

--INSERT INTO Users (FirstName, LastName, RoleId) VALUES ('Erik', 'Andersson', 1)
--INSERT INTO Users (FirstName, LastName, RoleId) VALUES ('Sara', 'Nilsson', 2)

--SELECT 
--	Users.Id,
--	Users.FirstName,
--	Users.LastName,
--	Roles.RoleName
--FROM Users
--JOIN Roles ON Users.RoleId = Roles.Id

--INSERT INTO StatusTypes VALUES ('Ej påbörjad')
--INSERT INTO StatusTypes VALUES ('Pågående')
--INSERT INTO StatusTypes VALUES ('Avslutad')

--SELECT * FROM StatusTypes

--INSERT INTO Projects (Id, Title, Description, StartDate, EndDate, StatusId, CustomerId, UserId, ProductId)
--	VALUES ('P-101', 'Webbutveckling', 'Utveckling av ny webbplats', '2025-01-01', '2025-03-01', 2, 1, 1, 1)

--INSERT INTO Projects (Id, Title, Description, StartDate, EndDate, StatusId, CustomerId, UserId, ProductId)
--	VALUES ('P-102', 'Systemintegration', 'Integration av ERP-system', '2025-02-01', '2025-06-01', 1, 2, 2, 2)


--SELECT
--	P.Id,
--	P.Title,
--	P.Description,
--	P.StartDate,
--	P.EndDate,
--	ST.StatusName AS 'CurrentStatus',
--	C.CustomerName,
--	CONCAT(U.FirstName, ' ', U.LastName) AS 'ProjectOwner'	
--FROM Projects P
--JOIN StatusTypes ST ON P.StatusId = ST.Id
--JOIN Customers C ON P.CustomerId = C.Id
--JOIN Users U ON P.UserId = U.Id


--UPDATE Projects SET StatusId = 2 WHERE Id = 'P-102';


--SELECT
--	P.Id,
--	P.Title,
--	P.Description,
--	P.StartDate,
--	P.EndDate,
--	ST.StatusName AS 'CurrentStatus',
--	C.CustomerName,
--	CONCAT(U.FirstName, ' ', U.LastName) AS 'ProjectOwner'	
--FROM Projects P
--JOIN StatusTypes ST ON P.StatusId = ST.Id
--JOIN Customers C ON P.CustomerId = C.Id
--JOIN Users U ON P.UserId = U.Id

--DELETE FROM Projects WHERE CustomerId = 2
--DELETE FROM CustomerContacts WHERE CustomerId = 2
--DELETE FROM Customers WHERE Id = 2

--SELECT * FROM CustomerContacts
--SELECT * FROM Customers

SELECT
	P.Id,
	P.Title,
	P.Description,
	P.StartDate,
	P.EndDate,
	ST.StatusName AS 'CurrentStatus',
	C.CustomerName,
	CONCAT(U.FirstName, ' ', U.LastName) AS 'ProjectOwner'	
FROM Projects P
JOIN StatusTypes ST ON P.StatusId = ST.Id
JOIN Customers C ON P.CustomerId = C.Id
JOIN Users U ON P.UserId = U.Id