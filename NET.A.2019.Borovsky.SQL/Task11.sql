-- Pre-last hired employee with fetch and offset keywords;

USE Northwind;

SELECT EmployeeID FROM Employees ORDER BY HireDate DESC OFFSET 1 ROWS FETCH FIRST 1 ROWS ONLY;