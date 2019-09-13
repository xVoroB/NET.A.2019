-- Company names from Berlin, London, Madrid, Bruxelles, Paris ordered by id in reverse;

USE Northwind;

SELECT CompanyName 
FROM Customers
WHERE City IN ('Berlin', 'London', 'Madrid' , 'Bruxelles', 'Paris')
ORDER BY CustomerID DESC;