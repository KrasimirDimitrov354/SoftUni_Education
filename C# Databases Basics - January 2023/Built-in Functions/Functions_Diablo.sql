USE [Diablo]

--14. Games from 2011 and 2012 Year
--Find and display the top 50 games which start date is from 2011 and 2012 year.
--Order them by start date, then by name of the game. The start date should be in the format "yyyy-MM-dd". 
SELECT TOP(50) [Name],
			   FORMAT([Start], 'yyyy-MM-dd')
			   AS [Start]
  FROM [Games]
 WHERE YEAR([Start]) IN (2011, 2012)
 ORDER BY [Start], [Name]

--15. User Email Providers
--Find all users with information about their email providers.
--Display the username and email provider. Sort the results by email provider alphabetically, then by username. 
SELECT [Username],
	   SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email]))
	   AS [Email Provider]
  FROM [Users]
 ORDER BY [Email Provider], [Username]

--16. Get Users with IP Address Like Pattern
--Find all users with their IP addresses, sorted by username alphabetically.
--Display only the rows which IP address matches the pattern: "***.1^.^.***". 
--Legend: 
--* - one symbol
--^ - one or more symbols
SELECT [Username],
	   [IpAddress]
	   AS [IP Address] 
  FROM [Users]
 WHERE [IpAddress] LIKE '___.1_%._%.___'
 ORDER BY [Username]

--17. Show All Games with Duration and Part of the Day
--Find all games with part of the day and duration.
--Sort them by game name alphabetically, then by duration (alphabetically, not by the timespan) and part of the day (all ascending).
--Part of the Day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24).
--Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration). 
SELECT [Name] AS [Game],
	    CASE
			WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			ELSE 'Evening'
	    END
	   AS [Part of the Day],
	    CASE
			WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
		END
	   AS [Duration]
  FROM [Games] AS [g]
 ORDER BY [Game], [Duration], [Part of the Day]