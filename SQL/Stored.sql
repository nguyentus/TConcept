CREATE PROC CreateOrder
(
	@CustomerID INT,
	@Notes NTEXT,
	@ProductID INT,
	@Quantity INT
)
AS
BEGIN
	INSERT INTO Orders 
	VALUES(@CustomerID, CONVERT(VARCHAR, GETDATE(), 121), @Notes)

	DECLARE @OrderID INT
	SELECT TOP(1) @OrderID = OrderID FROM Orders WHERE @CustomerID = CustomerID ORDER BY OrderDate DESC

	INSERT INTO OrderDetails
	VALUES(@OrderID, @ProductID, @Quantity, @Notes)
END
GO
EXEC CreateOrder 1, 'ship vào phòng khách nha!!!', 1, 3
GO

---
CREATE PROC GetCustomerId
(
	@UserName NVARCHAR(100),
	@UserPassword NVARCHAR(100)
)
AS
BEGIN
	SELECT c.CustomerID
	FROM Accounts a, Customers c
	WHERE a.AccountID = c.AccountID AND @UserName = a.UserName AND @UserPassword = a.UserPassword    
END
GO
EXEC GetCustomerId 'nguyentu2909', '1'
GO

---
CREATE PROC GetProductById
(
	@ProductId INT
)
AS
BEGIN
	select p.*, c.CategoryName 
	from Products p, Categories c
	where p.CategoryID = c.CategoryID AND @ProductId = p.ProductID 
END
GO
exec GetProductById 1
go

---
CREATE PROC GetAllInfoOrder
AS
BEGIN
	SELECT o.OrderID, c.FullName, o.OrderDate, SUM(p.Price * od.Quantity) AS Total 
	FROM Orders o, OrderDetails od, Customers c, Products p
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
	SELECT * 
	FROM Orders o, OrderDetails od, Products p, Customers c
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
	 select p.*, c.CategoryName 
	 from Products p, Categories c
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