-- Beverages and seafood with units in stock less than 20 and possible to order;

use Northwind;

select p.ProductName, p.UnitsInStock, s.ContactName, s.Phone 
from Products as p 
inner join Categories as c 
on p.CategoryID = c.CategoryID
inner join Suppliers as s
ON p.SupplierID = s.SupplierID
where c.CategoryName in ('Beverages', 'Seafood') 
AND p.UnitsInStock < 20 
AND p.Discontinued = 'false'
order by p.UnitsInStock ASC;
