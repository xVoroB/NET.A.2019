-- Countries from customers table in alphabetical order without duplicates;

USE Northwind;

SELECT DISTINCT Country FROM Customers ORDER BY Country ASC;