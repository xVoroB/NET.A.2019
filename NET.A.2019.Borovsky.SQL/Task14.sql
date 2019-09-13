-- Rewrite the query

use Northwind;

select distinct s.CompanyName,  
MIN(p.UnitPrice) as MinPrice,
MAX(p.UnitPrice) as MaxPrice
from Products as p 
inner join Suppliers as s 
on p.SupplierID = s.SupplierID
group by s.CompanyName
order by s.CompanyName asc;