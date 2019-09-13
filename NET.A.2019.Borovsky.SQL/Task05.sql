-- Companies id with required date of september 1996 in alphabetical order;

USE Northwind;

SELECT CustomerID 
FROM Orders
WHERE RequiredDate between '19960901' and '19960930' 
ORDER BY CustomerID ASC;