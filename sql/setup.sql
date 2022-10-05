
DROP DATABASE IF EXISTS LearningDb2;
GO
CREATE DATABASE LearningDb2;
GO
USE LearningDb2;
GO

DROP TABLE IF EXISTS [transaction];
DROP TABLE IF EXISTS till;
DROP TABLE IF EXISTS [user];
DROP TABLE IF EXISTS transactionItem;
DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS category;



CREATE TABLE [user]
(userId INT NOT NULL IDENTITY(1,1),
name VARCHAR(50) NOT NULL,
username VARCHAR(20) NOT NULL,
role VARCHAR(10) NOT NULL CHECK (role IN('admin','attendant')),
phoneNumber CHAR(10),
password CHAR(64) NOT NULL,
[access] VARCHAR(10) NOT NULL DEFAULT "granted" CHECK (access IN('granted','revoked','reset'))
UNIQUE(username),
PRIMARY KEY (userId));

CREATE TABLE category
(categoryId INT NOT NULL IDENTITY(1,1),
name VARCHAR(25) NOT NULL,
PRIMARY KEY(categoryId));

CREATE TABLE product
(productId INT NOT NULL IDENTITY(1,1),
barcode VARCHAR(10) NOT NULL,
name VARCHAR(30) NOT NULL,
categoryId INT NOT NULL,
stock INT NOT NULL,
reorderLevel INT DEFAULT 0 ,
costPrice MONEY NOT NULL,
sellingPrice MONEY NOT NULL,
PRIMARY KEY (productId),	
UNIQUE(barcode),
CONSTRAINT product_category FOREIGN KEY (categoryId) REFERENCES category (categoryId));

CREATE TABLE till
(tillId INT NOT NULL IDENTITY(1,1),
[open] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
[close] DATETIME,
userId INT,
PRIMARY KEY (tillId),
CONSTRAINT attendant_till FOREIGN KEY (userId) REFERENCES [user] (userId));

CREATE TABLE transactionItem
(transactionItemId INT NOT NULL IDENTITY(1,1),
productId INT,
quantity INT,
unitPrice MONEY NOT NULL,
price MONEY NOT NULL,
PRIMARY KEY (transactionItemId),
CONSTRAINT transactionItem_product FOREIGN KEY (productId) REFERENCES product (productId));

CREATE TABLE [transaction]
(transactionId INT NOT NULL IDENTITY(1,1),
transactionItem VARCHAR(max),
time DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
tillId INT,
total MONEY,
PRIMARY KEY (transactionId),
CONSTRAINT transaction_till FOREIGN KEY (tillId) REFERENCES till (tillId));
 CREATE TABLE reorders
(reorderId INT NOT NULL IDENTITY(1,1),
productId INT,
reorderDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
PRIMARY KEY (reorderId),
CONSTRAINT reorder_product FOREIGN KEY (productId) REFERENCES product(productId)); 

GO

CREATE TRIGGER reorderLevel ON product AFTER UPDATE AS  BEGIN SELECT CASE WHEN reorderLevel<1 THEN 0 WHEN stock>reorderLevel THEN 0 ELSE 1 END AS reorderTime FROM inserted  END 
