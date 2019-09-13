-- Customers from London which ordered ship by Speedy Express and employees from London office who took that orders;

USE Northwind;

SELECT DISTINCT c.CompanyName AS Customer,
CONCAT(e.FirstName, ' ', e.LastName) AS Employee 
FROM Customers AS c 
INNER JOIN Orders AS o 
ON c.CustomerID = o.CustomerID
INNER JOIN Employees AS e 
ON o.EmployeeID = e.EmployeeID
INNER JOIN Shippers AS s 
ON o.ShipVia = s.ShipperID
WHERE s.CompanyName = 'Speedy Express' 
AND c.City = 'London' 
AND e.City = 'London';