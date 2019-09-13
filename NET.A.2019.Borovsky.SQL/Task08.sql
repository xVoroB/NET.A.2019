-- Countries with more than 10 companies in reverse count order;

USE Northwind;

SELECT Country, Count(*) AS CustomerCount 
FROM Customers 
GROUP BY Country 
HAVING Count(*) >= 10  
ORDER BY CustomerCount DESC;