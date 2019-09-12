-- 3 most valuable orders after 1 of september 1997 shipped in South America;

use Northwind;

select CustomerID, ShipCountry, (select SUM(UnitPrice * Quantity * (1- Discount))
from [Order Details] where Orders.OrderID = [Order Details].OrderID
group by [Order Details].OrderID) as OrderPrice
FROM Orders where OrderDate >= '19970901' 
and ShipCountry in ('Argentina', 'Bolivia', 'Brazil', 'Chile', 'Equador', 'Paraguay', 'Peru', 'Suriname', 'Uruguay', 'Guyana', 'Colombia')
order by OrderPrice desc
offset 0 rows
fetch first 3 rows only;