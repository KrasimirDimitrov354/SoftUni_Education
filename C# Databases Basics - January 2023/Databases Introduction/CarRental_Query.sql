--14. Car Rental Database
--Using SQL queries create CarRental database with the following entities:
--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
--		StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--
--Set the most appropriate data types for each column. Set a primary key to each table. Populate each table with only 3 records.
--Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional.

CREATE DATABASE [CarRental]
USE [CarRental]

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[CategoryName] VARCHAR(20) NOT NULL,
	[DailyRate] FLOAT(10) CHECK ([DailyRate] >= 0),
	[WeeklyRate] FLOAT(10) CHECK ([WeeklyRate] >= 0),
	[MonthlyRate] FLOAT(10) CHECK ([MonthlyRate] >= 0),
	[WeekendRate] FLOAT(10) CHECK ([WeekendRate] >= 0)
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[PlateNumber] NCHAR(8) NOT NULL CHECK (LEN([PlateNumber]) = 8),
	[Manufacturer] NVARCHAR(20),
	[Model] NVARCHAR(20),
	[CarYear] CHAR(4) CHECK (LEN([CarYear]) = 4),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Doors] CHAR CHECK([Doors] IN(2, 4)) DEFAULT 2,
	[Picture] NVARCHAR(100),
	[Condition] NVARCHAR(150),
	[Available] VARCHAR(3) CHECK([Available] IN ('Yes', 'No')) DEFAULT 'Yes'
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] NVARCHAR(15) NOT NULL,
	[LastName] NVARCHAR(15) NOT NULL,
	[Title] NVARCHAR(15),
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[DriverLicenceNumber] CHAR(9) CHECK (LEN([DriverLicenceNumber]) = 9),
	[FullName] NVARCHAR(30),
	[Address] NVARCHAR(90),
	[City] NVARCHAR(15),
	[ZIPCode] CHAR(4) CHECK (LEN([ZIPCode]) = 4),
	[Notes] NVARCHAR(50)
)

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
	[CarId] INT FOREIGN KEY REFERENCES Cars(Id),
	[TankLevel] VARCHAR(5) CHECK([TankLevel] IN ('Empty', 'Half', 'Full')) DEFAULT 'Full',
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATE,
	[EndDate] DATE,
	[TotalDays] INT,
	[RateApplied] FLOAT(10),
	[TaxRate] FLOAT(1),
	[OrderStatus] VARCHAR(15) CHECK([OrderStatus] IN ('Completed', 'In Progress')),
	[Notes] NVARCHAR(50)
)

INSERT INTO [Categories](CategoryName)
VALUES
	('Economy'),
	('Truck'),
	('Motorbike')

INSERT INTO [Cars](PlateNumber, CategoryId)
VALUES
	('CPGYW8FM', 2),
	('VPSOTPU4', 1),
	('FMCNPS3T', 3)

INSERT INTO [Employees](FirstName, LastName)
VALUES
	('Pesho', 'Goshov'),
	('Baba', 'Yaga'),
	('Big', 'Chungus')

INSERT INTO [Customers](DriverLicenceNumber, FullName)
VALUES
	('314412096', 'Ali Baba'),
	('641619233', 'Gosho Peshov'),
	('004031396', 'Amogus')

INSERT INTO [RentalOrders](EmployeeId, CustomerId, CarId, OrderStatus)
VALUES
	(1, 2, 3, 'Completed'),
	(2, 3, 1, 'In Progress'),
	(3, 1, 2, 'Completed')