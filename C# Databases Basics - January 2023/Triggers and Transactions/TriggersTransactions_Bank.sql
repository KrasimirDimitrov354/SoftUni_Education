USE [Bank]

--1. Create Table Logs
--Create a table Logs(LogId, AccountId, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE [Logs]
(
	[LogId] INT PRIMARY KEY IDENTITY(1, 1),
	[AccountId] INT,
	[OldSum] MONEY,
	[NewSum] MONEY
)

CREATE TRIGGER [tr_AddBalanceChangesToLog]
			ON [Accounts]
		   FOR UPDATE
		    AS
		 BEGIN
			  INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
				   SELECT [d].[Id],
						  [d].[Balance],
						  [i].[Balance]
				     FROM [deleted] AS [d]
						JOIN [inserted] AS [i] ON [d].[Id] = [i].[Id]
		   END

--2. Create Table Emails
--Create a table NotificationEmails(Id, Recipient, Subject, Body).
--Add a trigger to the Logs table and create a new email whenever a new record is inserted in it.
--The following data is required to be filled for each email:
--•	Recipient – AccountId
--•	Subject – "Balance change for account: {AccountId}"
--•	Body - "On {date} your balance was changed from {old} to {new}."
CREATE TABLE [NotificationEmails]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Recipient] INT NOT NULL,
	[Subject] NVARCHAR(50) NOT NULL,
	[Body] NVARCHAR(500) NOT NULL
)

CREATE TRIGGER [tr_SendEmailWhenNewLogIsCreated]
			ON [Logs]
		 AFTER INSERT
		    AS
		 BEGIN
				  DECLARE @CurrentDate VARCHAR(30)
					  SET @CurrentDate = CONVERT(VARCHAR, GETDATE(), 0)

			  INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
				   SELECT [i].[AccountId],
						  CONCAT('Balance change for account: ', [i].[AccountId]),
						  CONCAT('On ', @CurrentDate, ' your balance was changed from ',
								[i].[OldSum], ' to ', [i].[NewSum], '.')
				     FROM [inserted] AS [i]
		   END

--3. Deposit Money
--Add stored procedure usp_DepositMoney(AccountId, MoneyAmount) that deposits money to an existing account.
--Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after the decimal point.
--The procedure should produce exact results working with the specified precision.
CREATE PROCEDURE [usp_DepositMoney](@AccountId INT, @MoneyAmount DECIMAL(18, 4))
			  AS
		   BEGIN
				IF @MoneyAmount > 0
				  BEGIN
					   UPDATE [Accounts]
						  SET [Balance] += @MoneyAmount
						WHERE [Id] = @AccountId
				    END
			 END

--4. Withdraw Money Procedure
--Add stored procedure usp_WithdrawMoney (AccountId, MoneyAmount) that withdraws money from an existing account.
--Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after decimal point.
--The procedure should produce exact results working with the specified precision.
CREATE PROCEDURE [usp_WithdrawMoney](@AccountId INT, @MoneyAmount DECIMAL(18, 4))
			  AS
		   BEGIN
				IF @MoneyAmount > 0
				  BEGIN 
					   UPDATE [Accounts]
						  SET [Balance] -= @MoneyAmount
						WHERE [Id] = @AccountId AND [Balance] - @MoneyAmount >= 0
				    END
			 END

--5. Money Transfer - NOT FINISHED
--Create stored procedure usp_TransferMoney(SenderId, ReceiverId, Amount) that transfers money from one account to another.
--Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after the decimal point.
--Make sure that the whole procedure passes without errors and if an error occurs make no change in the database.
--Use the usp_DepositMoney and usp_WithdrawMoney procedures. 
CREATE PROCEDURE [usp_TransferMoney](@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
			  AS
		   BEGIN
				EXEC [dbo].[usp_WithdrawMoney] @AccountId = @SenderId, @MoneyAmount = @Amount
			 END