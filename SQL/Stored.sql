CREATE PROC DeleteOrder
(
	@OrderID INT
)
AS
BEGIN
	DELETE OrderDetails WHERE OrderID = @OrderID
	DELETE Orders WHERE OrderID = @OrderID
END
GO

EXEC DeleteOrder 28
GO

---------------------------------------------------------------------------------------------------------
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

---------------------------------------------------------------------------------------------------------
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

---------------------------------------------------------------------------------------------------------
CREATE PROC GetProductById
(
	@ProductId INT
)
AS
BEGIN
	SELECT p.*, c.CategoryName 
	FROM Products p, Categories c
	WHERE p.CategoryID = c.CategoryID AND @ProductId = p.ProductID 
END
GO

EXEC GetProductById 1
go

---------------------------------------------------------------------------------------------------------
CREATE PROC GetAllInfoOrder
AS
BEGIN
	SELECT o.OrderID, c.FullName, o.OrderDate, SUM(p.Price * od.Quantity) AS Total 
	FROM Orders o, OrderDetails od, Customers c, Products p
	WHERE o.OrderID = od.OrderID 
		AND c.CustomerID = o.CustomerID
		AND od.ProductID = p.ProductID
	GROUP BY o.OrderID, c.FullName, o.OrderDate
END
GO

EXEC GetAllInfoOrder 
GO

---------------------------------------------------------------------------------------------------------
CREATE PROC GetOrderDetailById (@OrderID INT)
AS
BEGIN
	SELECT * 
	FROM Orders o, OrderDetails od, Products p, Customers c
	WHERE o.OrderID = od.OrderID 
		AND c.CustomerID = o.CustomerID
		AND od.ProductID = p.ProductID
		AND o.OrderID = @OrderID
END
GO
EXEC GetOrderDetailById 1
GO
---------------------------------------------------------------------------------------------------------
CREATE PROC GetAllProductsByStored
AS
BEGIN
	 SELECT p.*, c.CategoryName 
	 FROM Products p, Categories c
	 WHERE p.CategoryID = c.CategoryID
END
GO

EXEC GetAllProductsByStored
GO

---------------------------------------------------------------------------------------------------------
CREATE PROC DeleteProductById (@ProductID int)
AS
BEGIN
	IF NOT EXISTS (SELECT ProductID FROM OrderDetails WHERE @ProductID = ProductID)
	BEGIN
		DELETE Orders WHERE OrderID IN (SELECT OrderID FROM OrderDetails WHERE @ProductID = ProductID)
		DELETE OrderDetails WHERE @ProductID = ProductID
		DELETE Products WHERE @ProductID = ProductID
	END
END
GO