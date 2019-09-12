-- Customers with ship average freight more or equals than 100 or less than 10 which were shipped in UK and Canada;

USE Northwind;

SELECT CustomerId, Round(AVG(Freight), 0) AS FreightAvg FROM Orders WHERE ShipCountry in ('Canada', 'UK') 
GROUP BY CustomerID HAVING AVG(Freight) >= 100 OR AVG(Freight) < 10 ORDER BY FreightAvg DESC;