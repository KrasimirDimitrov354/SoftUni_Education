--12. Countries Holding 'A' 3 or More Times
--Find all countries which hold the letter 'A' at least 3 times in their name (case-insensitively).
--Sort the result by ISO code and display the "Country Name" and "ISO Code".
SELECT [CountryName] AS [Country Name],
	   [IsoCode] AS [ISO Code]
  FROM [Countries]
 WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', '')) >= 3
 ORDER BY [IsoCode]

--13. Mix of Peak and River Names
--Combine all peak names with all river names.
--The last letter of each peak name must be the same as the first letter of its corresponding river name.
--Display the peak names, river names and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.
SELECT [Peaks].[PeakName],
	   [Rivers].[RiverName],
	   CONCAT(LOWER(SUBSTRING([PeakName], 1, LEN([PeakName]) - 1)), LOWER([RiverName]))
	   AS [Mix]
  FROM [Peaks], [Rivers]
 WHERE LOWER(RIGHT([PeakName], 1)) = LOWER(LEFT([RiverName], 1))
 ORDER BY [Mix]