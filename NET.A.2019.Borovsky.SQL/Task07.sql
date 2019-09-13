-- Cities and companies-customers count in scandnavian countries;

USE Northwind;

SELECT City, COUNT(*) AS CustomerCount 
FROM Customers 
WHERE Country in ('Finland', 'Norway', 'Sweden') 
Group BY City;