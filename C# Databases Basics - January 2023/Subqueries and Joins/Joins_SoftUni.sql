USE [SoftUni]

--1. Employee Address
--Create a query that selects:
--•	EmployeeId
--•	JobTitle
--•	AddressId
--•	AddressText
--Return the first 5 rows sorted by AddressId in ascending order.
  SELECT TOP (5) [e].[EmployeeID],
				 [e].[JobTitle],
				 [e].[AddressID],
				 [a].[AddressText]
    FROM [Employees] AS [e] LEFT JOIN [Addresses] AS [a]
      ON [e].[AddressID] = [a].[AddressID]
ORDER BY [e].[AddressID]

--2. Addresses with Towns
--Write a query that selects:
--•	FirstName
--•	LastName
--•	Town
--•	AddressText
--Sort them by FirstName in ascending order, then by LastName. Select the first 50 employees.
  SELECT TOP (50) [e].[FirstName],
				  [e].[LastName],
				  [t].[Name],
				  [a].[AddressText]
    FROM [Addresses] AS [a]
		INNER JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
		INNER JOIN [Employees] AS [e] ON [a].[AddressID] = [e].[AddressID]
ORDER BY [e].[FirstName], [e].[LastName]

--3. Sales Employee
--Create a query that selects:
--•	EmployeeID
--•	FirstName
--•	LastName
--•	DepartmentName
--Sort them by EmployeeID in ascending order. Select only employees from the "Sales" department.
  SELECT [e].[EmployeeID],
		 [e].[FirstName],
		 [e].[LastName],
		 [d].[Name]
    FROM [Employees] AS [e] JOIN [Departments] AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID]

--4. Employee Departments
--Create a query that selects:
--•	EmployeeID
--•	FirstName 
--•	Salary
--•	DepartmentName
--Filter only employees with a salary higher than 15000. Return the first 5 rows, sorted by DepartmentID in ascending order.
  SELECT TOP (5) [e].[EmployeeID],
				 [e].[FirstName],
				 [e].[Salary],
				 [d].[Name]
    FROM [Employees] AS [e] JOIN [Departments] AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [e].[Salary] > 15000
ORDER BY [e].[DepartmentID]

--5. Employees Without Project
--Create a query that selects:
--•	EmployeeID
--•	FirstName
--Filter only employees without a project. Return the first 3 rows, sorted by EmployeeID in ascending order.
  SELECT TOP (3) [e].[EmployeeID],
				 [e].[FirstName]
    FROM [Employees] AS [e] LEFT JOIN [EmployeesProjects] AS [ep]
	  ON [e].[EmployeeID] = [ep].[EmployeeID]
   WHERE [ep].[ProjectID] IS NULL
ORDER BY [e].[EmployeeID]

--6. Employees Hired After
--Create a query that selects:
--•	FirstName
--•	LastName
--•	HireDate
--•	DeptName
--Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" department. Sort them by HireDate (ascending).
  SELECT [e].[FirstName],
		 [e].[LastName],
		 [e].[HireDate],
		 [d].[Name]
    FROM [Employees] AS [e] JOIN [Departments] AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [e].[HireDate] > '01-01-1999' AND [d].[Name] IN ('Sales', 'Finance')
ORDER BY [e].[HireDate]

--7. Employees with Project
--Create a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date).
--Return the first 5 rows sorted by EmployeeID in ascending order.
  SELECT TOP (5) [e].[EmployeeID],
				 [e].[FirstName],
				 [p].[Name] AS [ProjectName]
    FROM [EmployeesProjects] AS [ep]
		INNER JOIN [Employees] AS [e] ON [ep].[EmployeeID] = [e].[EmployeeID]
		JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [p].[StartDate] > '08-13-2002' AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID]

--8. Employee 24
--Create a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.
  SELECT [e].[EmployeeID],
	     [e].[FirstName],
			CASE
				WHEN DATEPART(YEAR, [p].[StartDate]) >= 2005 THEN NULL
				ELSE [p].Name
			END
		 AS [ProjectName]
    FROM [EmployeesProjects] AS [ep]
		INNER JOIN [Employees] AS [e] ON [ep].[EmployeeID] = [e].[EmployeeID]
		JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [e].[EmployeeID] = 24

--9. Employee Manager
--Create a query that selects:
--•	EmployeeID
--•	FirstName
--•	ManagerID
--•	ManagerName
--Filter all employees with a manager who has ID equals to 3 or 7. Return all the rows, sorted by EmployeeID in ascending order.
  SELECT [e].[EmployeeID],
		 [e].[FirstName],
		 [m].[EmployeeID],
		 [m].[FirstName]
    FROM [Employees] AS [m] INNER JOIN [Employees] AS [e]
	  ON [m].[EmployeeID] = [e].[ManagerID]
   WHERE [e].[ManagerID] IN (3, 7)
ORDER BY [e].[EmployeeID]

--10. Employees Summary
--Create a query that selects:
--•	EmployeeID
--•	EmployeeName
--•	ManagerName
--•	DepartmentName
--Show the first 50 employees with their managers and the departments they are in (show the departments of the employees). Order them by EmployeeID.
  SELECT TOP (50) [e].[EmployeeID],
					CONCAT([e].[FirstName], ' ', [e].[LastName])
				  AS [EmployeeName],
					CONCAT([m].[FirstName], ' ', [m].[LastName])
				  AS [ManagerName],
				  [d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]
		INNER JOIN [Employees] AS [m] ON [e].[ManagerID] = [m].[EmployeeID]
		JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID]

--11. Min Average Salary
--Create a query that returns the value of the lowest average salary of all departments.
SELECT MIN([avg].[AverageSalaries]) AS [MinAverageSalary]
  FROM
	(
		  SELECT AVG([Salary]) AS [AverageSalaries]
		    FROM [Employees] AS [e]
		GROUP BY [DepartmentID]
	) AS [avg]