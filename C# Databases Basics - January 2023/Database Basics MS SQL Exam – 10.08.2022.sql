CREATE DATABASE [NationalTouristSitesOfBulgaria]
GO

USE [NationalTouristSitesOfBulgaria]
GO

CREATE TABLE [Tourists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL CHECK([Age] BETWEEN 0 AND 120),
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)

CREATE TABLE [BonusPrizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes]
(
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]),
	[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes]([Id]),
	PRIMARY KEY([TouristId], [BonusPrizeId])
)

CREATE TABLE [Locations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50),
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Sites]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT NOT NULL FOREIGN KEY REFERENCES [Locations]([Id]),
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories]([Id]),
	[Establishment] VARCHAR(15)
)

CREATE TABLE [SitesTourists]
(
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]),
	[SiteId] INT FOREIGN KEY REFERENCES [Sites]([Id]),
	PRIMARY KEY([TouristId], [SiteId])
)

INSERT INTO [Tourists]
VALUES
	('Borislava Kazakova', 52, '+359896354244',	'Bulgaria', NULL),
	('Peter Bosh', 48, '+447911844141', 'UK', NULL),
	('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
	('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
	('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)
GO

INSERT INTO [Sites]
VALUES
	('Ustra fortress', 90, 7, 'X'),
	('Karlanovo Pyramids', 65, 7, NULL),
	('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
	('Sinite Kamani Natural Park', 17, 1, NULL),
	('St. Petka of Bulgaria – Rupite', 92, 6, '1994')
GO

UPDATE [Sites]
   SET [Establishment] = '(not defined)'
 WHERE [Establishment] IS NULL
GO

DELETE FROM [TouristsBonusPrizes]
      WHERE [BonusPrizeId] = 5
GO

DELETE FROM [BonusPrizes]
	  WHERE [Name] = 'Sleeping bag'
GO

--5. Tourists
--Extract information about all the Tourists – name, age, phone number and nationality.
--Order the result by nationality (ascending), then by age (descending), and then by tourist name (ascending).
  SELECT [Name],
		 [Age],
		 [PhoneNumber],
		 [Nationality]
    FROM [Tourists]
ORDER BY [Nationality],
		 [Age] DESC,
		 [Name]
GO

--6. Sites with their Location and Category
--Select all sites and find their location and category.
--Select the name of the tourist site, name of the location,  establishment year/century and name of the category.
--Order the result by name of the category (descending), then by name of the location (ascending) and then by name of the site itself (ascending).
  SELECT *
    FROM (
  		  SELECT [s].[Name] AS [Site],
    	  		 [l].[Name] AS [Location],
    	  		 [s].[Establishment],
    	         [c].[Name] AS [Category]
  		    FROM [Sites] AS [s]
    	  		JOIN [Locations] AS [l] ON [s].[LocationId] = [l].[Id]
    	  		JOIN [Categories] AS [c] ON [s].[CategoryId] = [c].[Id]
  	     ) AS [ValuesSubquery] 
ORDER BY [Category] DESC,
		 [Location],
		 [Site]
GO

--7. Count of Sites in Sofia Province
--Extract all locations which are in Sofia province. Find the count of sites in every location.
--Select the name of the province, name of the municipality, name of the location and count of the tourist sites in it.
--Order the result by count of tourist sites (descending) and then by name of the location (ascending).
  SELECT [l].[Province],
		 [l].[Municipality],
		 [l].[Name] AS [Location],
		 COUNT([s].[Id]) AS [CountOfSites]
    FROM [Sites] AS [s]
		JOIN [Locations] AS [l] ON [s].[LocationId] = [l].[Id]
   WHERE [l].[Province] = 'Sofia'
GROUP BY [l].[Province],
		 [l].[Municipality],
		 [l].[Name],
		 [s].[LocationId]
ORDER BY [CountOfSites] DESC,
		 [Location]
GO

--8. Tourist Sites established BC
--Extract information about the tourist sites which:
--•	have a location name that doesn't start with the letters 'B', 'M' or 'D'
--• are established Before Christ (BC).
--Select the site name, location name, municipality, province and establishment.
--Order the result by name of the site (ascending).
  SELECT [s].[Name] AS [Site],
  	     [l].[Name] AS [Location],
  	     [l].[Municipality],
  	     [l].[Province],
  	     [s].[Establishment]
    FROM [Sites] AS [s]
  	  JOIN [Locations] AS [l] ON [s].[LocationId] = [l].[Id]
   WHERE [l].[Name] LIKE '[^BDM]%' AND [s].[Establishment] LIKE '_% BC'
ORDER BY [s].[Name]
GO

--9. Tourists with their Bonus Prizes
--Extract information about the tourists along with their bonus prizes. If there is no data for the bonus prize put '(no bonus prize)'.
--Select tourist's name, age, phone number, nationality and bonus prize.
--Order the result by the name of the tourist (ascending).
  SELECT [t].[Name],
		 [t].[Age],
		 [t].[PhoneNumber],
		 [t].[Nationality],
			ISNULL([bp].[Name], '(no bonus prize)')
		 AS [Reward]
    FROM [Tourists] AS [t]
		LEFT JOIN [TouristsBonusPrizes] AS [tbp] ON [t].[Id] = [tbp].[TouristId]
		LEFT JOIN [BonusPrizes] AS [bp] ON [tbp].[BonusPrizeId] = [bp].[Id]
ORDER BY [t].[Name]
GO

--10. Tourists visiting History and Archaeology sites
--Extract all tourists who have visited sites from category 'History and archaeology'.
--Select their last name, nationality, age and phone number.
--Order the result by their last name (ascending).
  SELECT DISTINCT SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name]) - CHARINDEX(' ', [t].[Name]))
	  AS [LastName],
		 [t].[Nationality],
		 [t].[Age],
		 [t].[PhoneNumber]
    FROM [Tourists] AS [t]
		INNER JOIN [SitesTourists] AS [st] ON [t].[Id] = [st].[TouristId]
		INNER JOIN [Sites] AS [s] ON [st].[SiteId] = [s].[Id]
		INNER JOIN [Categories] AS [c] ON [s].[CategoryId] = [c].[Id]
   WHERE [c].[Name] = 'History and archaeology'
GO

--11. Tourists Count on a Tourist Site
--Create a user-defined function named udf_GetTouristsCountOnATouristSite (@Site) which:
--•	receives a tourist site
--•	returns the count of tourists who have visited it.
CREATE FUNCTION [udf_GetTouristsCountOnATouristSite] (@Site VARCHAR(100))
		RETURNS INT
			 AS
		  BEGIN
				DECLARE @Count INT

				SELECT @Count = COUNT([st].[TouristId])
								 FROM [SitesTourists] AS [st]
									  JOIN [Sites] AS [s] ON [s].[Id] = [st].[SiteId]
							    WHERE [s].[Name] = @Site
							 GROUP BY [s].[Name]

				RETURN @Count
		    END
GO

SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Regional History Museum – Vratsa') AS [Output]
SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Samuil’s Fortress') AS [Output]
SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Gorge of Erma River') AS [Output]
GO

--12.	Annual Reward Lottery
--Create a stored procedure named usp_AnnualRewardLottery(@TouristName).
--Update the reward of the given tourist according to the count of the sites they have visited:
--•	>= 100 receives 'Gold badge'
--•	>= 50 receives 'Silver badge'
--•	>= 25 receives 'Bronze badge'
--Extract the name of the tourist and the reward they have.
CREATE PROCEDURE [usp_AnnualRewardLottery] @TouristName VARCHAR(50)
			  AS
		   BEGIN
				DECLARE @VisitedSites INT

				 SELECT @VisitedSites = COUNT([st].[SiteId])
										 FROM [Tourists] AS [t]
										      LEFT JOIN [SitesTourists] AS [st] ON [t].[Id] = [st].[TouristId]
										WHERE [t].[Name] = @TouristName
									 GROUP BY [t].[Name]

				 UPDATE [Tourists]
					SET [Reward] = (
									CASE
										WHEN @VisitedSites >= 100 THEN 'Golden badge'
										WHEN @VisitedSites >= 50 THEN 'Silver badge'
										WHEN @VisitedSites >= 25 THEN 'Bronze badge'
									 END
								   )

				 SELECT [Name],
						[Reward]
				   FROM [Tourists]
				  WHERE [Name] = @TouristName
		     END
GO

EXEC [dbo].[usp_AnnualRewardLottery] @TouristName = 'Gerhild Lutgard'
EXEC [dbo].[usp_AnnualRewardLottery] @TouristName = 'Teodor Petrov'
EXEC [dbo].[usp_AnnualRewardLottery] @TouristName = 'Zac Walsh'
EXEC [dbo].[usp_AnnualRewardLottery] @TouristName = 'Brus Brown'