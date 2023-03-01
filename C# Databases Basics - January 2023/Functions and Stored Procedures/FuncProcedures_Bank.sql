USE [Bank]

--9. Find Full Name
--Write a stored procedure usp_GetHoldersFullName that selects the full name of all people. 
CREATE PROCEDURE [usp_GetHoldersFullName]
			  AS
		   BEGIN
				SELECT CONCAT([FirstName], ' ', [LastName])
					AS [Full Name]
				  FROM [AccountHolders]
			 END

EXEC [dbo].[usp_GetHoldersFullName]

--10. People with Balance Higher Than Entered
--Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan that accepts a number as a parameter.
--It should return all the people who have more money in total in all their accounts than the supplied number.
--Order them by their first name, then by their last name.
CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @TargetBalance DECIMAL(18, 4)
			  AS
		   BEGIN
				  SELECT [ah].[FirstName] AS [First Name],
				  	     [ah].[LastName] AS [Last Name]
				    FROM [AccountHolders] AS [ah]
				   WHERE @TargetBalance < (
										     SELECT SUM([a].[Balance])
										       FROM [Accounts] AS [a]
										  	  WHERE [a].[AccountHolderId] = [ah].[Id]
										   GROUP BY [a].[AccountHolderId]
										  )
				ORDER BY [ah].[FirstName], [ah].[LastName]
			 END

EXEC [dbo].usp_GetHoldersWithBalanceHigherThan @TargetBalance = 30000

--11. Future Value Function
--Your task is to create a function ufn_CalculateFutureValue that accepts as parameters:
--• sum (decimal)
--• yearly interest rate (float)
--• number of years (int)
--It should calculate and return the future value of the initial sum rounded up to the fourth digit after the decimal delimiter.
--Use the following formula: Future Value = S * ((1 + YIR) power NOY)
CREATE FUNCTION [ufn_CalculateFutureValue] (@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
		RETURNS DECIMAL(18, 4)
			 AS
		  BEGIN
				DECLARE @FutureValue DECIMAL(18, 4)
				    SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
				 RETURN @FutureValue
		    END

SELECT [dbo].[ufn_CalculateFutureValue]([InitialSum], [YearlyInterestRate], [NumberOfYears])
	AS [Output]
  FROM (
		SELECT 1000 AS [InitialSum],
			   0.10 AS [YearlyInterestRate],
			   5 AS [NumberOfYears]
       ) AS [ValuesSubquery]

--12. Calculating Interest
--Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem.
--Give an interest to a person's account for 5 years, along with information about their account id, first name, last name and current balance.
--It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE [usp_CalculateFutureValueForAccount] (@AccountId INT, @YearlyInterestRate FLOAT)
			  AS
		   BEGIN
				DECLARE @NumberOfYears INT
				    SET @NumberOfYears = 5
				
				 SELECT *,
						[dbo].[ufn_CalculateFutureValue]([Current Balance], @YearlyInterestRate, @NumberOfYears)
						AS [Balance in 5 years]
				   FROM (
							SELECT [accH].[Id] AS [Account Id],
								   [accH].[FirstName] AS [First Name],
								   [accH].[LastName] AS [Last Name],
								   [acc].[Balance] AS [Current Balance]
							  FROM [AccountHolders] AS [accH]
								INNER JOIN [Accounts] AS [acc] ON [accH].[Id] = [acc].[AccountHolderId]
							 WHERE [acc].[Id] = @AccountId
						) AS [AccInfoSubquery]
		     END

EXEC [dbo].[usp_CalculateFutureValueForAccount] @AccountId = 1, @YearlyInterestRate = 0.1