-- Pre-last hired employee;

USE Northwind;

SELECT EmployeeID FROM Employees 
WHERE HireDate = (SELECT MAX(HireDate) FROM Employees 
WHERE HireDate < (SELECT MAX(HireDate) FROM Employees));