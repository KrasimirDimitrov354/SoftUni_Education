CREATE DATABASE [Boardgames]
GO

USE [Boardgames]
GO

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(100) NOT NULL,
	[StreetNumber] INT NOT NULL,
	[Town] VARCHAR(30) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	[ZIP] INT NOT NULL
)

CREATE TABLE [Publishers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL UNIQUE,
	[AddressID] INT NOT NULL FOREIGN KEY REFERENCES [Addresses]([Id]),
	[Website] NVARCHAR(40),
	[Phone] NVARCHAR(20)
)

CREATE TABLE [PlayersRanges]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlayersMin] INT NOT NULL,
	[PlayersMax] INT NOT NULL
)

CREATE TABLE [Boardgames]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[YearPublished] INT NOT NULL,
	[Rating] DECIMAL(4, 2) NOT NULL,
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories]([Id]),
	[PublisherId] INT NOT NULL FOREIGN KEY REFERENCES [Publishers]([Id]),
	[PlayersRangeId] INT NOT NULL FOREIGN KEY REFERENCES [PlayersRanges]([Id])
)

CREATE TABLE [Creators]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(30) NOT NULL
)

CREATE TABLE [CreatorsBoardgames]
(
	[CreatorId] INT FOREIGN KEY REFERENCES [Creators]([Id]),
	[BoardgameId] INT FOREIGN KEY REFERENCES [Boardgames]([Id]),
	PRIMARY KEY([CreatorId], [BoardgameId])
)

--5. Boardgames by Year of Publication
--Select all boardgames ordered by year of publication (ascending), then by name (descending). 
--Required columns:
--•	Name
--•	Rating
  SELECT [Name],
		 [Rating]
    FROM [Boardgames]
ORDER BY [YearPublished],
		 [Name] DESC

--6. Boardgames by Category
--Select all boardgames with "Strategy Games" or "Wargames" categories.
--Order results by YearPublished (descending).
--Required columns:
--•	Id
--•	Name
--•	YearPublished
--•	CategoryName
  SELECT [b].[Id],
		 [b].[Name],
		 [b].[YearPublished],
		 [c].[Name] AS [CategoryName]
    FROM [Boardgames] AS [b]
		 JOIN [Categories] AS [c] ON [b].[CategoryId] = [c].[Id]
   WHERE [b].[CategoryId] IN (6, 8)
ORDER BY [b].[YearPublished] DESC

--7. Creators without Boardgames
--Select all creators without boardgames. Order them by name (ascending).
--Required columns:
--•	Id
--•	CreatorName (creator's first and last name, concatenated with space)
--•	Email
  SELECT [c].[Id],
			CONCAT([c].[FirstName], ' ', [c].[LastName])
		 AS [CreatorName],
		 [c].[Email]
    FROM [Creators] AS [c]
		LEFT JOIN [CreatorsBoardgames] AS [cb] ON [c].[Id] = [cb].[CreatorId]
   WHERE [cb].[BoardgameId] IS NULL

--8. First 5 Boardgames
--Select the first 5 boardgames that have
--•	rating bigger than 7.00 and containing the letter 'a' in the boardgame name
--• a boardgame rating bigger than 7.50 and the range of the min and max count of players is [2;5].
--Order the result by boardgames name (ascending), then by rating (descending).
--Required columns:
--•	Name
--•	Rating
--•	CategoryName
  SELECT TOP (5) [b].[Name],
				 [b].[Rating],
				 [c].[Name] AS [CategoryName]
    FROM [Boardgames] AS [b]
		JOIN [PlayersRanges] AS [pr] ON [b].[PlayersRangeId] = [pr].[Id]
		JOIN [Categories] AS [c] ON [b].[CategoryId] = [c].[Id]
   WHERE ([b].[Rating] > 7 AND [b].[Name] LIKE '%a%')
      OR ([b].[Rating] > 7.5 AND [pr].[PlayersMin] = 2 AND [pr].[PlayersMax] = 5)
ORDER BY [b].[Name],
		 [b].[Rating] DESC

--9. Creators with Emails
--Select all of the creators that have emails ending in ".com", and display their most highly rated boardgame.
--Order by creator full name (ascending).
--Required columns:
--•	FullName
--•	Email
--•	Rating
  SELECT [FullName],
  	     [Email],
  	     [Rating]
    FROM (
  		  SELECT CONCAT([c].[FirstName], ' ', [c].[LastName])
  				 AS [FullName],
  				 [c].[Email] AS [Email],
  				 [b].[Rating] AS [Rating],
  				 DENSE_RANK() OVER (PARTITION BY [c].[Id] ORDER BY [b].[Rating] DESC)
  				 AS [Rank]
  			FROM [Creators] AS [c]
  				JOIN [CreatorsBoardgames] AS [cb] ON [c].[Id] = [cb].[CreatorId]
  				JOIN [Boardgames] AS [b] ON [cb].[BoardgameId] = [b].[Id]
  		   WHERE [c].[Email] LIKE '%.com'
  	     ) AS [BoardgamesRankedSubquery]
   WHERE [Rank] = 1
ORDER BY [FullName]

--10. Creators by Rating
--Select all creators who have created a boardgame. Select their last name, average rating (rounded up to the next biggest integer) and publisher's name.
--Show only the results for creators whose games are published by "Stonemaier Games".
--Order the results by average rating (descending).
  SELECT [LastName],
  		  CEILING([AverageRatingDecimal])
		 AS [AverageRating],
  		 [PublisherName]
  	FROM (
  			SELECT [c].[LastName],
  					AVG([b].[Rating])
  	  		  	   AS [AverageRatingDecimal],
  	  		  	   [p].[Name] AS [PublisherName]
  	          FROM [Creators] AS [c]
  	  		    JOIN [CreatorsBoardgames] AS [cb] ON [c].[Id] = [cb].[CreatorId]
  	  		    JOIN [Boardgames] AS [b] ON [cb].[BoardgameId] = [b].[Id]
  	  		    JOIN [Publishers] AS [p] ON [b].[PublisherId] = [p].[Id]
  	         WHERE [p].[Name] = 'Stonemaier Games'
  	      GROUP BY [p].[Name],
  	  		       [c].[LastName]
         ) AS [CreatorStoneMaierAverageRatingSubquery]
ORDER BY [AverageRatingDecimal] DESC

--11. Creator with Boardgames
--Create a user-defined function named udf_CreatorWithBoardgames(@name) that receives a creator's first name.
--The function should return the total number of boardgames that the creator has created.
CREATE FUNCTION [udf_CreatorWithBoardgames] (@Name NVARCHAR(30))
		RETURNS INT
			 AS
		  BEGIN
			   DECLARE @TotalGames INT
			    SELECT @TotalGames = COUNT([cb].[BoardgameId])
									  FROM [Creators] AS [c]
										INNER JOIN [CreatorsBoardgames] AS [cb] ON [c].[Id] = [cb].[CreatorId]
									 WHERE [c].[FirstName] = @Name
								  GROUP BY [c].[FirstName]

					IF @TotalGames IS NULL
						SET @TotalGames = 0
				RETURN @TotalGames
		    END

SELECT [dbo].[udf_CreatorWithBoardgames]('Bruno') AS [Output]
SELECT [dbo].[udf_CreatorWithBoardgames]('Pesho') AS [Output]

--12. Search for Boardgame with Specific Category
--Create a stored procedure named usp_SearchByCategory(@category) that receives category.
--The procedure must print the following information about all boardgames with the given category:
--•	Name
--•	YearPublished
--•	Rating
--•	CategoryName
--•	PublisherName
--•	MinPlayers
--•	MaxPlayers.
--Add " people" at the end of the min and max count of people.
--Order them by PublisherName (ascending) and YearPublished (descending).
CREATE PROCEDURE [usp_SearchByCategory] @Category VARCHAR(50)
			  AS
		   BEGIN
				  SELECT [b].[Name],
						 [b].[YearPublished],
						 [b].[Rating],
						 [c].[Name] AS [CategoryName],
						 [p].[Name] AS [PublisherName],
						 CONCAT([pr].[PlayersMin], ' people') AS [MinPlayers],
						 CONCAT([pr].[PlayersMax], ' people') AS [MaxPlayers]
				    FROM [Boardgames] AS [b]
						JOIN [Categories] AS [c] ON [b].[CategoryId] = [c].[Id]
						JOIN [Publishers] AS [p] ON [b].[PublisherId] = [p].[Id]
						JOIN [PlayersRanges] as [pr] ON [b].[PlayersRangeId] = [pr].[Id]
				   WHERE [c].[Name] = @Category
				ORDER BY [p].[Name],
						 [b].[YearPublished] DESC
		     END

EXEC [dbo].[usp_SearchByCategory] @Category = 'Wargames'

INSERT INTO [Boardgames]
VALUES
	('Deep Blue', 2019, 5.67, 1, 15, 7),
	('Paris', 2016, 9.78, 7, 1, 5),
	('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
	('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
	('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO [Publishers]
VALUES
	('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
	('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
	('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

UPDATE [PlayersRanges]
   SET [PlayersMax] += 1
 WHERE [PlayersMin] = 2 AND [PlayersMax] = 2

UPDATE [Boardgames]
   SET [Name] = CONCAT([Name], 'V2')
 WHERE [YearPublished] >= 2020

DELETE FROM [CreatorsBoardgames]
	  WHERE [BoardgameId] IN (1, 16, 31, 47) 

DELETE FROM [Boardgames]
      WHERE [PublisherId] IN (1, 16)

DELETE FROM [Publishers]
	  WHERE [AddressID] = 5

DELETE FROM [Addresses]
	  WHERE [Town] LIKE 'L%'