-- Contact name of company with phone code 171 and 77 in it and fax with 171 at the beggining and 50 at the end;

USE Northwind;

SELECT ContactName FROM Customers WHERE Phone LIKE '(171)%77%' AND Fax LIKE '(171)%50' ORDER BY CustomerID ASC;