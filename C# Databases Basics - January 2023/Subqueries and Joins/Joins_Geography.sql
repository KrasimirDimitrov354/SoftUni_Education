USE [Geography]

--12. Highest Peaks in Bulgaria
--Create a query that selects:
--•	CountryCode
--•	MountainRange
--•	PeakName
--•	Elevation
--Filter all the peaks in Bulgaria, which have elevation over 2835. Return all the rows, sorted by elevation in descending order.
  SELECT [md].[CountryCode],
		 [m].[MountainRange],
		 [p].[PeakName],
		 [p].[Elevation]
    FROM [Mountains] AS [m]
		JOIN [MountainsCountries] AS [md] ON [m].[Id] = [md].[MountainId]
		JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
   WHERE [p].[Elevation] > 2835 AND [md].[CountryCode] = 'BG'
ORDER BY [p].[Elevation] DESC

--13. Count Mountain Ranges
--Create a query that selects:
--•	CountryCode
--•	MountainRanges
--Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
  SELECT [md].[CountryCode],
		 COUNT([md].[CountryCode]) AS [MountainRanges]
    FROM [MountainsCountries] AS [md]
   WHERE [CountryCode] IN ('BG', 'RU', 'US')
GROUP BY [md].[CountryCode]

--14. Countries With or Without Rivers
--Create a query that selects:
--•	CountryName
--•	RiverName
--Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
  SELECT TOP (5) [c].[CountryName],
				 [r].[RiverName]
    FROM [Countries] AS [c]
	  LEFT JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
	  LEFT JOIN [Rivers] AS [r] ON [r].[Id] = [cr].[RiverId]
   WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName]

--15. Continents and Currencies
--Create a query that selects:
--•	ContinentCode
--•	CurrencyCode
--•	CurrencyUsage
--Find all continents and their most used currency. Filter any currency, which is used in only one country. Sort your results by ContinentCode.
SELECT [ContinentCode],
	   [CurrencyCode],
	   [CurrencyUsage]
  FROM
	(
		SELECT *,
			   DENSE_RANK() OVER
				(PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
			   AS [Rank]
		  FROM
		(
			SELECT [ContinentCode],
				   [CurrencyCode],
				   COUNT([CurrencyCode]) AS [CurrencyUsage]
			  FROM [Countries]
		  GROUP BY [ContinentCode], [CurrencyCode]
			HAVING COUNT([CurrencyCode]) > 1
		) AS [UnrankedUsageQuery]
	) AS [RankedUsageQuery]
 WHERE [Rank] = 1

--16. Countries Without Any Mountains
--Create a query that returns the count of all countries, which don’t have a mountain.
  SELECT COUNT([c].[CountryCode]) AS [Count]
    FROM [Countries] AS [c]
	  LEFT JOIN [MountainsCountries] AS [mt] ON [c].[CountryCode] = [mt].[CountryCode]
   WHERE [mt].[MountainId] IS NULL
GROUP BY [mt].[MountainId]

--17. Highest Peak and Longest River by Country
--Find the elevation of the highest peak and the length of the longest river for each country.
--Sort by:
--•	the highest peak elevation (from highest to lowest)
--•	the longest river length (from longest to smallest)
--•	country name (alphabetically)
--Display NULL when no data is available in some of the columns. Limit only the first 5 rows.
  SELECT TOP (5) [c].[CountryName],
  				 MAX([p].[Elevation]) AS [HighestPeakElevation],
  				 MAX([r].[Length]) AS [LongestRiverLength]
    FROM [Countries] AS [c]
  	  LEFT JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
  	  LEFT JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
  	  LEFT JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
  	  LEFT JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
  	  LEFT JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
GROUP BY [c].[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [c].[CountryName]

--18. Highest Peak Name and Elevation by Country
--Find the name and elevation of the highest peak for each country, along with its mountain.
--When no peaks are available in some countries, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as a mountain name.
--When multiple peaks in some countries have the same elevation, display all of them.
--Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
  SELECT TOP (5)
		 [CountryName] AS [Country],
  	     ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
  	     ISNULL([Elevation], 0) AS [Highest Peak Elevation],
  	     ISNULL([MountainRange], '(no mountain)') AS [Mountain]
    FROM
    (
         SELECT [c].[CountryName],
    	        [p].[PeakName],
    	        [p].[Elevation],
    	        [m].[MountainRange],
  	 		    DENSE_RANK() OVER (PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation])
  	 	        AS [PeakRank]
           FROM [Countries] AS [c]
    	     LEFT JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
    	     LEFT JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
    	     LEFT JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
    ) AS [PeakRankingSubquery]
   WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]