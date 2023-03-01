USE [SoftUni]

--13. Departments Total Salaries
--Create a query that shows the total sum of salaries for each department. Order them by DepartmentID.
  SELECT [DepartmentID],
			SUM([Salary])
		 AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14. Employees Minimum Salaries
--Select the minimum salary from the employees hired after 01/01/2000 in departments with IDs 2, 5 and 7.
  SELECT [DepartmentID],
			MIN([Salary])
		 AS [MinimumSalary]
    FROM [Employees]
   WHERE [HireDate] > '01-01-2000' AND [DepartmentID] IN (2, 5, 7)
GROUP BY [DepartmentID]

--15. Employees Average Salaries
--Select all employees who earn more than 30000 into a new table.
--Then delete all employees who have ManagerID = 42 (in the new table).
--Then increase the salaries of all employees with DepartmentID = 1 by 5000. Finally, select the average salaries in each department.
SELECT *
  INTO [RichEmployees]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE FROM [RichEmployees]
	  WHERE [ManagerID] = 42

UPDATE [RichEmployees]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID],
			AVG([Salary])
		 AS [AverageSalary]
    FROM [RichEmployees]
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries
--Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.
  SELECT [DepartmentID],
			MAX([Salary])
		 AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000

--17. Employees Count Salaries
--Count the salaries of all employees, who don’t have a manager.
SELECT COUNT([Salary]) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

--18. 3rd Highest Salary
--Find the third highest salary in each department if there is such. 
SELECT DISTINCT [DepartmentID],
				[Salary] AS [ThirdHighestSalary]
  FROM (
		  SELECT *,
		  	     DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC)
		  	     AS [SalaryRank]
		    FROM [Employees]
		 ) AS [SalaryRankingSubquery]
 WHERE [SalaryRank] = 3

--19. Salary Challenge
--Create a query that returns:
--•	FirstName
--•	LastName
--•	DepartmentID
--Select all employees who have salary higher than the average salary of their respective departments. Select only the first 10 rows. Order them by DepartmentID.
  SELECT TOP (10) [e].[FirstName],
  				  [e].[LastName],
  				  [e].[DepartmentID]
    FROM [Employees] AS [e]
   WHERE [e].[Salary] > (
						   SELECT AVG([Salary]) AS [AverageSalary]
						     FROM [Employees] AS [avg]
							WHERE [avg].[DepartmentID] = [e].[DepartmentID]
						 GROUP BY [DepartmentID]
						)
ORDER BY [e].[DepartmentID]