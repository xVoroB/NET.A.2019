-- Sum of freights of ships in the second half of july 1996 with the freights more or equals than average freight sorted from low to high;

USE Northwind;

SELECT CustomerID, SUM(Freight) AS FreightSum 
FROM Orders 
WHERE Freight >= (SELECT AVG(Freight) FROM Orders AS AvgFreight 
WHERE AvgFreight.CustomerID = Orders.CustomerID) 
AND ShippedDate BETWEEN '19960716' AND '19960731' 
GROUP BY CustomerID 
ORDER BY FreightSum ASC;