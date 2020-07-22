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
	Image ntext,
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
	--Chú ý PRIMARY KEY khi mua nhiều sản phẩm
	PRIMARY KEY(OrderID, ProductID),
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID) 
)
GO
CREATE TABLE Attributes
(
	ProductID int,
	Image ntext

	FOREIGN KEY (ProductID) REFERENCES Products(ProductID) 
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
values (N'Rana', 1, 102, 96, 215, 'PU', N'Đen', 26000000, 5, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img1.png?alt=media&token=a74f6cc5-f4ea-4add-a3b7-13a6c9e80b0e', N'Sofa Rana'),
		(N'Amery', 1, 89 , 262, 317, N'Da Santos', N'Đen', 97000000, 1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img2.png?alt=media&token=9abb4e1c-9238-4fe6-a229-c8c0d3ef6b41', N'Sofa Amery góc phải'),
		(N'Copenhagen', 1, 84 , 142, 238, N'Vải Loki', N'Kem', 34700000, 1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img3.png?alt=media&token=0ffc36b7-9ea5-4f65-8a67-c3e24f19c942', N'Sofa Copenhagen góc trái'),
		(N'Charlietown', 1, 78, 78, 169 , N'Vải Nhung', N'Xanh đậm', 15000000, 3, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img4.png?alt=media&token=fa936e18-8ed7-4ca9-b09f-400aaad4a6d7', N'Charlietown ghế dài'),
		(N'Doria', 1, 83, 83, 183, N'Vải Holly', N'Xanh lá', 18000000, 3, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img5.png?alt=media&token=9a7bf8db-d434-44d1-96cc-60a51f8028fc', N'Sofa Doria 3 chỗ'),
		(N'Charlietown', 1, 78, 88, 219, N'Vải Nhung', N'Xanh biển', 22000000, 1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img6.png?alt=media&token=21bdc762-373f-4283-bc11-2f5529bb7cca', N'Sofa Charlietown 3 chỗ'),
		(N'Horsens', 1, 60, 106, 303, N'Da Bò', N'Nâu', 154000000, 1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img7.png?alt=media&token=a9d28a79-c2af-4345-8f17-c9b68acc60d7', N'Sofa Horsens góc trái'),
		(N'Charlietown', 1, 78, 88, 91, N'Vải Nhung', N'Xanh biển', 15000000, 7, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img8.png?alt=media&token=c78acb47-ee84-4859-bc00-3cec223a9dba', N'Sofa Charlietown 1 chỗ'),
		(N'Cremona', 1, 87, 192, 98, N'Vải Rio', N'Xám đậm', 14000000, 2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img9.png?alt=media&token=8d253cc9-def0-4d22-a9b5-dccf42931552', N'Sofa giường Cremona'),
		(N'Faith', 1, 91, 98, 196, N'Vải Town', N'Xanh đậm', 11000000, 2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img10.png?alt=media&token=94427930-3a10-4933-9ff4-e1753beb6a55', N'Sofa giường Faith')

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

INSERT Attributes
values (1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img1.png?alt=media&token=a74f6cc5-f4ea-4add-a3b7-13a6c9e80b0e'),
		(1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img1(1).png?alt=media&token=96de8ded-8bec-4fd1-88a6-815d8f9d6cf7'),
		(1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img1(2).png?alt=media&token=a66023b8-5290-413f-86ec-66a8adc08ba8'),
		(1, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img1(3).png?alt=media&token=f47038b5-2757-4c56-a30c-c41589fc6c8b'),
		(2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img2.png?alt=media&token=9abb4e1c-9238-4fe6-a229-c8c0d3ef6b41'),
		(2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img2(1).png?alt=media&token=17d71b3e-6096-41f6-bd6b-d84c0173cd6c'),
		(2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img2(2).png?alt=media&token=0252d92c-49e8-41ab-86cb-6e20bee5b680'),
		(2, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img2(3).png?alt=media&token=f7d5a946-688f-4ff7-91d3-37a0f614742d'),
		(3, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img3.png?alt=media&token=0ffc36b7-9ea5-4f65-8a67-c3e24f19c942'),
		(4, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img4.png?alt=media&token=fa936e18-8ed7-4ca9-b09f-400aaad4a6d7'),
		(5, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img5.png?alt=media&token=9a7bf8db-d434-44d1-96cc-60a51f8028fc'),
		(6, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img6.png?alt=media&token=21bdc762-373f-4283-bc11-2f5529bb7cca'),
		(6, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img6(1).png?alt=media&token=6517cc44-dc4c-4a48-ad5b-c736ed93b06c'),
		(6, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img6(2).png?alt=media&token=9d87f0dd-0389-48c3-8004-5072d3117356'),
		(7, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img7(1).png?alt=media&token=67b8b92a-0ccc-40b7-ab9b-ebb8fb26f5b4'),
		(7, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img7.png?alt=media&token=a9d28a79-c2af-4345-8f17-c9b68acc60d7'),
		(7, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img7(2).png?alt=media&token=97cec7cf-6ea5-47ce-a2c5-f0e202c10418'),
		(7, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img7(3).png?alt=media&token=5a2985aa-64bd-494b-a5bb-e66da7814cd4'),
		(8, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img8.png?alt=media&token=c78acb47-ee84-4859-bc00-3cec223a9dba'),
		(8, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img8(1).png?alt=media&token=7e425a6e-c5f0-48d0-9097-45bc3d976726'),
		(8, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img8(2).png?alt=media&token=d55c5e93-7f76-4d5e-a769-182232bebcf3'),
		(9, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img9(1).png?alt=media&token=87a1e3d4-5eac-49bf-8ba1-07f22182af82'),
		(9, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img9.png?alt=media&token=8d253cc9-def0-4d22-a9b5-dccf42931552'),
		(9, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img9(3).png?alt=media&token=eeb01e86-411a-4628-a001-edcd7114c35a'),
		(10, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img10.png?alt=media&token=94427930-3a10-4933-9ff4-e1753beb6a55'),
		(10, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img10(1).png?alt=media&token=4d8c17db-2ab4-40c1-ae5a-bfda87b75676'),
		(10, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img10(2).png?alt=media&token=b281170c-acd9-4db9-a4b2-cd1fd15554dc'),
		(10, 'https://firebasestorage.googleapis.com/v0/b/tconcept-e8cbc.appspot.com/o/img10(3).png?alt=media&token=5af4db9d-8ea7-4d9e-b857-34f654b099fc')
