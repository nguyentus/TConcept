CREATE DATABASE TConcept
GO
USE TConcept
GO

--- CREATE TABLE
CREATE TABLE Roles
(
	RoleID int primary key,
	RoleName nvarchar(100)  not null,
	Notes ntext
)
GO
CREATE TABLE Accounts
(
	AccountID int identity primary key,
	RoleID int,
	UserName nvarchar(100) not null,
	UserPassword nvarchar(100) not null,
	Notes ntext,

	foreign key (RoleID) references Roles (RoleID)
)
GO
CREATE TABLE Categories 
(
	CategoryID int IDENTITY (1, 1) primary key,
	CategoryName nvarchar(100) NOT NULL ,
	Description ntext,
)
GO
CREATE TABLE Customers 
(
	CustomerID int IDENTITY (1, 1) primary key,
	FullName nvarchar (100) NOT NULL,
	AccountID int,
	BirthDate datetime,
	Address nvarchar (100),
	HomePhone nvarchar (24) ,
	Notes ntext,

	foreign key (AccountID) references Accounts (AccountID)
)
GO
CREATE TABLE Products
(
	ProductID int IDENTITY (1, 1) PRIMARY KEY,
	ProductName nvarchar (200) NOT NULL ,
	CategoryID int,
	Height float,
	Width float,
	Length float,
	Material nvarchar(40),
	Color nvarchar(40),
	Price float DEFAULT (0),
	Stock int,
	Notes ntext,

	FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) 
)
GO
CREATE TABLE Orders
(
	OrderID int IDENTITY (1, 1) PRIMARY KEY ,
	CustomerID int,
	OrderDate datetime,
	Notes ntext,

	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
GO
CREATE TABLE OrderDetails
(
	OrderID int,
	ProductID int,
	Quantity int DEFAULT (1),
	Notes ntext, 

	PRIMARY KEY(OrderID, ProductID),
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ProductID) REFERENCES ProductS(ProductID) 
)
GO

--- INSERT DATA
INSERT Roles
values (0, 'admin', 'This account has access and use the all in system'),
		(1, 'customer', 'Only the specific functions with the customer')

INSERT Accounts
values  (0, 'admin', '1', null),
		(1, 'yen', '1', null),
		(1, 'nguyentu2909', '1', null)

set dateformat dmy
INSERT Customers 
values (N'admin nè', 1, '4/6/2020', N'123 Hồng Hà', '(+84-123-456-789)', null),
		(N'HoangYen', 2, '4/6/2020', N'123 Hồng Hà', '(+84-123-456-789)', null),
		(N'Nguyễn Thanh Tú', 3, '29/09/1999', N'123 Hồng Hà', '(+84-123-456-789)', null)

INSERT Categories 
values (N'Sofa', N''),
		(N'Bàn', N''),
		(N'Ghế', N'để ngồi'),
		(N'Tủ', N'đựng đồ nhe'),
		(N'Giường', N'để nằm'),
		(N'Đồ trang trí', N''),
		(N'Hàng thanh lý', N'đồ qua sử dụng'),
		(N'Sale', N'thích thì mua'),
		(N'Best seller', N'không thích vẫn mua')

INSERT Products
values (N'Rana', 1, 102, 96, 215, 'PU', N'Đen', 26000000, 5, N'Sofa Rana'),
		(N'Amery', 1, 89 , 262, 317, N'Da Santos', N'Đen', 97000000, 1, N'Sofa Amery góc phải'),
		(N'Copenhagen', 1, 84 , 142, 238, N'Vải Loki', N'Kem', 34700000, 1, N'Sofa Copenhagen góc trái'),
		(N'Charlietown', 1, 78, 78, 169 , N'Vải Nhung', N'Xanh đậm', 15000000, 3, N'Charlietown ghế dài'),
		(N'Doria', 1, 83, 83, 183, N'Vải Holly', N'Xanh lá', 18000000, 3, N'Sofa Doria 3 chỗ'),
		(N'Charlietown', 1, 78, 88, 219, N'Vải Nhung', N'Xanh biển', 22000000, 1, N'Sofa Charlietown 3 chỗ'),
		(N'Horsens', 1, 60, 106, 303, N'Da Bò', N'Nâu', 154000000, 1, N'Sofa Horsens góc trái'),
		(N'Charlietown', 1, 78, 88, 91, N'Vải Nhung', N'Xanh biển', 15000000, 7, N'Sofa Charlietown 1 chỗ'),
		(N'Cremona', 1, 87, 192, 98, N'Vải Rio', N'Xám đậm', 14000000, 2, N'Sofa giường Cremona'),
		(N'Faith', 1, 91, 98, 196, N'Vải Town', N'Xanh đậm', 11000000, 2, N'Sofa giường Faith')

INSERT Orders
values (1, '4/6/2020', null),
		(2, '4/6/2020', null),
		(3, '4/6/2020', null),
		(1, '4/6/2020', null),
		(1, '5/6/2020', null),
		(2, '5/6/2020', null),
		(3, '5/6/2020', null),
		(3, '5/6/2020', null)

INSERT OrderDetails
values (1, 10, 1, null),
		(1, 9, 1, null),
		(2, 7, 1, null),
		(2, 8, 1, null),
		(3, 6, 1, null),
		(4, 5, 1, null),
		(5, 4, 1, null),
		(6, 3, 1, null),
		(7, 2, 1, null),
		(8, 1, 1, null)
