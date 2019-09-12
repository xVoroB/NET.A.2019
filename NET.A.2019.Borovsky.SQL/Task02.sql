-- Last hired employee;

USE Northwind;

Select EmployeeID from Employees where HireDate = (Select MAX(HireDate) from Employees);