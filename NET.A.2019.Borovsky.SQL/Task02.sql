-- Last hired employee;

USE Northwind;

SELECT top 1 EmployeeID 
FROM Employees 
order by HireDate desc;