select * from Product
select * from Customer
select * from ShoppingCart
select * from [Order]

SELECT 
                    p.*, 
                    MONTH(o.OrderDate) AS OrderMonth,
                    COUNT(*) AS ItemCount
                FROM ShoppingCart sc
                JOIN Product p ON sc.ProductId = p.Id
                JOIN [Order] o ON sc.OrderId = o.Id
                WHERE o.OrderDate >= DATEADD(MONTH, -3, GETDATE())
                    AND o.CustomerId = 6
                GROUP BY p.Id, p.Title, p.Description, p.Price, p.Category, p.Price, p.ImageUrl, MONTH(o.OrderDate);


SELECT 
    p.*, 
    MONTH(o.OrderDate) AS OrderMonth,
    COUNT(*) AS ItemCount,
    SUM(sc.Quantity) AS TotalQuantity
FROM ShoppingCart sc
JOIN Product p ON sc.ProductId = p.Id
JOIN [Order] o ON sc.OrderId = o.Id
WHERE o.OrderDate >= DATEADD(MONTH, -3, GETDATE())
    AND o.CustomerId = 6
GROUP BY p.Id, p.Title, p.Description, p.Price, p.Category, p.Price, p.ImageUrl, MONTH(o.OrderDate);

SELECT 
    p.*, 
    MONTH(o.OrderDate) AS OrderMonth,
    COUNT(*) AS ItemCount,
    SUM(sc.Quantity) AS TotalQuantity
FROM ShoppingCart sc
JOIN Product p ON sc.ProductId = p.Id
JOIN [Order] o ON sc.OrderId = o.Id
WHERE o.OrderDate >= DATEADD(MONTH, -3, GETDATE())
    AND o.CustomerId = 4
GROUP BY p.Id, p.Title, p.Description, p.Price, p.Category, p.Price, p.ImageUrl, MONTH(o.OrderDate)