
--
-- Wes Thompson
-- SOA 07
--


------------
--Database--
------------


--CREATE DATABASE Shop;



----------
--Tables--
----------


--TABLE: Customer
--DESCRIPTION: 
IF NOT EXISTS (SELECT * FROM sys.tables 
WHERE name = 'Customer')
BEGIN
	USE Shop
	CREATE TABLE Customer
	(
	custID INT IDENTITY(1,1) PRIMARY KEY,
	firstName nVARCHAR(50),
	lastName nVARCHAR(50),
	phoneNumber nVARCHAR(12)
	);
		--Populate our lookup table
	INSERT INTO Customer(firstName, lastName, phoneNumber) VALUES
	('Joe', 'Bzolay', '555-555-1212'),
	('Nancy', 'Finklbaum', '555-235-4578'),
	('Henry', 'Svitzinski', '555-326-8456');



END

--TABLE: product
--DESCRIPTION: 
IF NOT EXISTS (SELECT * FROM sys.tables 
WHERE name = 'Product')
BEGIN
	USE Shop
	CREATE TABLE Product
	(
	prodID INT IDENTITY(1,1) PRIMARY KEY,
	prodName nVARCHAR(100),
	price float,
	prodWeight float,
	inStock int
	);
			--Populate our lookup table
	INSERT INTO Product(prodName, price, prodWeight, inStock) VALUES
	('Grapple Grommet', 0.02, 0.005, 1),
	('Wandoozals', 2.35, 0.532, 1),
	('Kardoofals', 8.75, 5.650, 0);

END
GO

--TABLE: Order
--DESCRIPTION: 
IF NOT EXISTS (SELECT * FROM sys.tables 
WHERE name = 'Order')
BEGIN
	USE Shop
	CREATE TABLE "Order" 
	(
	orderID INT IDENTITY(1,1) PRIMARY KEY,
	custID int NOT NULL ,
	poNumber nvarchar(30),
	orderDate Datetime

	FOREIGN KEY (custID) REFERENCES Customer(custID)
	);
				--Populate our lookup table
	INSERT INTO "Order"(custID, orderDate, poNumber) VALUES
	(1, '2011-09-15', 'GRAP-09-2011-001'),
	(1, '2011-09-30', 'GRAP-09-2011-056'),
	(3, '2011-10-05', '');

END
GO

--TABLE: Order
--DESCRIPTION: 
IF NOT EXISTS (SELECT * FROM sys.tables 
WHERE name = 'Cart')
BEGIN
	USE Shop
	CREATE TABLE Cart
	(
	cartID INT IDENTITY(1,1) PRIMARY KEY,
	orderID int NOT NULL ,
		prodID int NOT NULL ,
	quantity int


	FOREIGN KEY (orderID) REFERENCES "Order"(orderID),
	FOREIGN KEY (prodID) REFERENCES Product(prodID)
	);
					--Populate our lookup table
	INSERT INTO Cart(orderID, prodID, quantity) VALUES
(1,1,500),
(1,2,1000),
(2,3,10),
(3,1,75),
(3,2,15),
(3,3,5);



END
GO


