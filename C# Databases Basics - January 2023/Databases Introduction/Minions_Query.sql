CREATE DATABASE Minions
USE Minions

CREATE TABLE Minions
(
	Id INT,
	[Name] VARCHAR(100),
	Age INT,
	PRIMARY KEY(Id)
);

CREATE TABLE Towns
(
	Id INT,
	[Name] VARCHAR(100),
	PRIMARY KEY(Id)
);

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

--7. Create Table People
--Using SQL query, create table People with the following columns:
--•	Id – unique number. For every person there will be no more than 231-1 people (auto incremented).
--•	Name – full name of the person. There will be no more than 200 Unicode characters (not null).
--•	Picture – image with size up to 2 MB (allow nulls).
--•	Height – in meters. Real number precise up to 2 digits after floating point (allow nulls).
--•	Weight – in kilograms. Real number precise up to 2 digits after floating point (allow nulls).
--•	Gender – possible states are m or f (not null).
--•	Birthdate – (not null).
--•	Biography – detailed biography of the person. It can contain max allowed Unicode characters (allow nulls).
--Make the Id a primary key. Populate the table with only 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE People
(
	Id BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(3, 2),
	Gender CHAR NOT NULL
	CONSTRAINT ck_Enum CHECK (Gender IN('m','f')),
	Birthdate DATE NOT NUll,
	Biography NVARCHAR(MAX),
);

INSERT INTO People([Name], Birthdate, Gender)
VALUES
	('Pesho', '1998-11-01', 'm'),
	('Gosho', '1998-11-01' ,'m'),
	('Pena', '1998-11-01' ,'f'),
	('Grozdana', '1998-11-01' ,'f'),
	('Pesho2', '1998-11-01' ,'m');