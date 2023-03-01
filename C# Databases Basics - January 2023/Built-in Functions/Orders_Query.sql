USE [Orders]

--18. Orders Table
--You are given a table Orders(Id, ProductName, OrderDate) filled with data.
--The payment for that order must be accomplished 3 days after the order date, and the delivery date is after 1 month.
--Write a query to show each product's name, order date, pay and deliver due dates.
SELECT [ProductName],
	   [OrderDate],
	    DATEADD(DAY, 3, [OrderDate])
	   AS [Pay Due],
	    DATEADD(MONTH, 1, [OrderDate])
	   AS [Deliver Due]
  FROM [Orders]