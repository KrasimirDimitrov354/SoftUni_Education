--22. All Mountain Peaks
--Display all the mountain peaks in alphabetical order.
SELECT [PeakName]
  FROM [Peaks]
 ORDER BY [PeakName] ASC

--23. Biggest Countries by Population
--Find the 30 biggest countries by population located in Europe. Display the "CountryName" and "Population".
--Order the results by population (from biggest to smallest), then by country alphabetically.
SELECT TOP (30) [CountryName],
				[Population]
  FROM [Countries]
 WHERE [ContinentCode] = ('EU')
 ORDER BY [Population] DESC,
		  [CountryName] ASC

--24. Countries and Currency
--Find all the countries with information about their currency.
--Display the "CountryName", "CountryCode", and information about its "Currency": either "Euro" or "Not Euro".
--Sort the results by country name alphabetically.
SELECT [CountryName],
	   [CountryCode],
	   CASE [CurrencyCode]
			WHEN 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
	   END
	   AS [Currency]
  FROM [Countries]
 ORDER BY [CountryName] ASC

--*Peaks in Rila
--Display all peaks for "Rila" mountain. Include:
--•	MountainRange
--•	PeakName
--•	Elevation
--Peaks should be sorted by elevation descending.
SELECT [Mountains].[MountainRange],
	   [Peaks].[PeakName], [Peaks].[Elevation]
  FROM [Peaks] INNER JOIN [Mountains]
    ON [Peaks].[MountainId] = [Mountains].[Id]
 WHERE [MountainId] = 17
 ORDER BY [Elevation] DESC