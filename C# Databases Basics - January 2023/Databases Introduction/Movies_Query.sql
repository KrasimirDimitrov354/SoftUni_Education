--13. Movies Database
--Using SQL queries create Movies database with the following entities:
--•	Directors (Id, DirectorName, Notes)
--•	Genres (Id, GenreName, Notes)
--•	Categories (Id, CategoryName, Notes)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
--Set the most appropriate data types for each column. Set a primary key to each table.
--Populate each table with exactly 5 records. Make sure the columns that are present in 2 tables would be of the same data type.
--Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(250)
);

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(250)
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(250)
);

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	[Length] TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating TINYINT,
	Notes VARCHAR(250)
);

INSERT INTO Directors(DirectorName)
VALUES
	('Martin Scorsese'),
	('Woody Allen'),
	('Kathryn Bigelow'),
	('James Cameron'),
	('George Lucas');

INSERT INTO Genres(GenreName)
VALUES
	('Action'),
	('Comedy'),
	('Drama'),
	('Thriller'),
	('Science Fiction');

INSERT INTO Categories(CategoryName)
VALUES
	('A'),
	('B'),
	('C'),
	('D'),
	('E');

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
VALUES
	('Movie1', 1, 1, 1),
	('Movie2', 2, 2, 2),
	('Movie3', 3, 3, 3),
	('Movie4', 4, 4, 4),
	('Movie5', 5, 5, 5);