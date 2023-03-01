USE [SoftUni]

--1. Employees with Salary Above 35000
--Create stored procedure usp_GetEmployeesSalaryAbove35000 that returns all employees' first and last names, whose salary above 35000.
CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
			  AS
		   BEGIN
				SELECT [FirstName],
					   [LastName]
				  FROM [Employees]
				 WHERE [Salary] > 35000
		     END

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

--2. Employees with Salary Above Number
--Create a stored procedure usp_GetEmployeesSalaryAboveNumber that accepts a number (of type DECIMAL(18,4)) as parameter.
--It must return all employees' first and last names, whose salary is above or equal to the given number. 
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @Number DECIMAL(18, 4)
			  AS
		   BEGIN
				SELECT [FirstName],
					   [LastName]
				  FROM [Employees]
				 WHERE [Salary] >= @Number
			 END

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] @Number = 35000

--3. Town Names Starting With
--Create a stored procedure usp_GetTownsStartingWith that accepts a string as parameter and returns all town names starting with that string. 
CREATE PROCEDURE [usp_GetTownsStartingWith] @Input NVARCHAR(40)
			  AS
           BEGIN
				SELECT [Name]
					AS [Town]
				  FROM [Towns]
				 WHERE LEFT([Name], LEN(@Input)) = @Input
             END

EXEC [dbo].[usp_GetTownsStartingWith] @Input = 'b'

--4. Employees from Town
--Create a stored procedure usp_GetEmployeesFromTown that accepts town name as parameter.
--It must return the first and last name of those employees, who live in the given town. 
CREATE PROCEDURE [usp_GetEmployeesFromTown] @TownName NVARCHAR(40)
			  AS
		   BEGIN
				SELECT [FirstName] AS [First Name],
				       [LastName] AS [Last Name]
				  FROM [Employees] AS [e]
					INNER JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
					INNER JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
				 WHERE [t].[Name] = @TownName
		     END

EXEC [dbo].[usp_GetEmployeesFromTown] @TownName = 'Sofia'

--5. Salary Level Function
--Create a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee and returns the level of the salary.
--•	If salary is < 30000, return "Low"
--•	If salary is between 30000 and 50000 (inclusive), return "Average"
--•	If salary is > 50000, return "High"
CREATE FUNCTION [ufn_GetSalaryLevel] (@Salary DECIMAL(18, 4))
		RETURNS VARCHAR(10)
			 AS
		  BEGIN
				DECLARE @SalaryLevel VARCHAR(10)

				IF @Salary < 30000
					BEGIN
						SET @SalaryLevel = 'Low'
					  END
				ELSE IF @Salary BETWEEN 30000 AND 50000
					BEGIN
						SET @SalaryLevel = 'Average'
					  END
				ELSE
					BEGIN
						SET @SalaryLevel = 'High'
					  END

				 RETURN @SalaryLevel
		    END

SELECT [Salary],
	   [dbo].[ufn_GetSalaryLevel]([Salary])
	AS [Salary Level]
  FROM [Employees]

--6. Employees by Salary Level
--Create a stored procedure usp_EmployeesBySalaryLevel that receives as parameter level of salary (low, average, or high).
--It must print the names of all employees who have the given level of salary.
--You should use the function - "dbo.ufn_GetSalaryLevel(@Salary)", which was part of the previous task.
CREATE PROCEDURE [usp_EmployeesBySalaryLevel] @SalaryLevel VARCHAR(10)
			  AS
		   BEGIN
				SELECT [FirstName] AS [First Name],
				       [LastName] AS [Last Name]
				  FROM [Employees]
				 WHERE @SalaryLevel = [dbo].[ufn_GetSalaryLevel]([Salary])
		     END

EXEC [dbo].[usp_EmployeesBySalaryLevel] @SalaryLevel = 'High'

--7. Define Function
--Define a function ufn_IsWordComprised(@setOfLetters, @word).
--Depending on whether or not the word is comprised of the given letters, the function should returns true or false.
CREATE FUNCTION [ufn_IsWordComprised] (@setOfLetters NVARCHAR(20), @word NVARCHAR(20))
		RETURNS BIT
			 AS
		  BEGIN
				DECLARE @result BIT,
						@counter INT
					SET @result = 0
					SET @counter = 1

				  WHILE (@counter <= LEN(@setOfLetters))
						BEGIN
							  DECLARE @currentLetter NVARCHAR(1)
								  SET @currentLetter = SUBSTRING(@setOfLetters, @counter, 1)

								  SET @word = REPLACE(@word, @currentLetter, '')
								   IF (LEN(@word) = 0)
									 BEGIN
									 	    SET @result = 1
									 	  BREAK
									   END
									    
								  SET @counter += 1
						  END
				 RETURN @result
		    END

SELECT *,
	   [dbo].[ufn_IsWordComprised]([SetOfLetters], [Word])
	   AS [Result]
  FROM
	 (
		SELECT 'oistmiahf' AS [SetOfLetters],
			   'Sofia' AS [Word]
	 ) AS [ValuesSubquery]

--8. Delete Employees and Departments
--Create a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT) which deletes all Employees from a given department.
--Delete these departments from the Departments table too.
--Select the number of employees from the given department. If the delete statements are correct the select query should return 0.
--After completing that exercise restore your database to revert all changes.
CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment] (@departmentId INT)
			  AS
		   BEGIN
				DELETE FROM [EmployeesProjects]
					  WHERE [EmployeeID] IN (
												SELECT [EmployeeID]
												  FROM [Employees]
												 WHERE [DepartmentID] = @departmentId
											)

				 ALTER TABLE [Departments]
				ALTER COLUMN [ManagerID] INT NULL

					  UPDATE [Departments]
					     SET [ManagerID] = NULL
					   WHERE [DepartmentID] = @departmentId

					  UPDATE [Employees]
					     SET [ManagerID] = NULL
					   WHERE [ManagerID] IN (
												SELECT [ManagerID]
												  FROM [Employees]
												 WHERE [DepartmentID] = @departmentId
											)

				 DELETE FROM [Employees]
				       WHERE [DepartmentID] = @departmentId
				 DELETE FROM [Departments]
					   WHERE [DepartmentID] = @departmentId

					  SELECT COUNT(*)
					    FROM [Employees]
					   WHERE [DepartmentID] = @departmentId
		     END

SELECT *
  FROM [Employees]
 WHERE [DepartmentID] = 3

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] @departmentId = 3