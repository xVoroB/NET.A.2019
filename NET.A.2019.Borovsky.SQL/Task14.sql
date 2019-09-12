-- Rewrite the query;

USE Northwind;

SELECT s.CompanyName, MIN(p.UnitPrice) AS MinPrice, MAX(p.UnitPrice) AS MaxPrice
FROM products AS p INNER JOIN suppliers AS s ON p.SupplierID = s.SupplierID
GROUP BY s.CompanyName ORDER BY s.CompanyName;
