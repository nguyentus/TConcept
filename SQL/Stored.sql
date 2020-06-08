---
CREATE PROC GetAllInfoOrder
AS
BEGIN
	SELECT o.OrderID, c.FullName, o.OrderDate, SUM(p.Price * od.ProductID) AS Total FROM Orders o, OrderDetails od, Customers c, Products p
	WHERE o.OrderID = od.OrderID 
		and c.CustomerID = o.CustomerID
		and od.ProductID = p.ProductID
	GROUP by o.OrderID, c.FullName, o.OrderDate
END
GO
exec GetAllInfoOrder 
go

--- 
CREATE PROC GetOrderDetailById (@OrderID int)
AS
BEGIN
	SELECT * FROM Orders o, OrderDetails od, Products p, Customers c
	WHERE o.OrderID = od.OrderID 
		and c.CustomerID = o.CustomerID
		and od.ProductID = p.ProductID
		and o.OrderID = @OrderID
END
GO
exec GetOrderDetailById 1
go
---
CREATE PROC GetAllProductsByStored
AS
BEGIN
	 select p.*, c.CategoryName from Products p, Categories c
	 where p.CategoryID = c.CategoryID
END
GO

exec GetAllProductsByStored
go

---
CREATE PROC DeleteProductById (@ProductID int)
AS
BEGIN
	if not exists (select ProductID from OrderDetails where @ProductID = ProductID)
	begin
		delete Orders where OrderID in (select OrderID from OrderDetails where @ProductID = ProductID)
		delete OrderDetails where @ProductID = ProductID
		delete Products where @ProductID = ProductID
	end
END
GO