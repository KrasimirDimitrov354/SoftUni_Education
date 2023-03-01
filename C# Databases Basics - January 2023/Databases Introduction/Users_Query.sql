--8. Create Table Users
--Using SQL query create table Users with columns:
--•	Id – unique number for every user. There will be no more than 263-1 users (auto incremented).
--•	Username – unique identifier of the user. It will be no more than 30 characters (non Unicode)  (required).
--•	Password – password will be no longer than 26 characters (non Unicode) (required).
--•	ProfilePicture – image with size up to 900 KB. 
--•	LastLoginTime
--•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
--Make the Id a primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE Users
(
	Id BIGINT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
);

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
	('Pesho', 'pass1', '1998-11-01', 0),
	('Gosho', 'pass2', '1998-11-01' , 1),
	('Pena', 'pass3', '1998-11-01' , 0),
	('Grozdana', 'pass4', '1998-11-01' , 1),
	('Pesho2', 'pass5', '1998-11-01' , 0);

--9. Change Primary Key
--Using SQL queries modify table Users from the previous task.
--First remove the current primary key and then create a new primary key that would be a combination of fields Id and Username.

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07DCC6F9FF;
ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, [Username]);

--10. Add Check Constraint
--Using SQL queries modify table Users.
--Add check constraint to ensure that the values in the Password field are at least 5 symbols long. 

ALTER TABLE Users
ADD CHECK (LEN([Password]) >= 5);

--11. Set Default Value of a Field
--Using SQL queries modify table Users.
--Make the default value of LastLoginTime field to be the current time.

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

--12. Set Unique Field
--Using SQL queries modify table Users.
--Remove Username field from the primary key so only the field Id would be primary key.
--Now add unique constraint to the Username field to ensure that the values there are at least 3 symbols long.

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername;
ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id);
ALTER TABLE Users
ADD CONSTRAINT UniqueUsername UNIQUE ([Username]);
ALTER TABLE Users
ADD CONSTRAINT UsernameLength CHECK (LEN([Username]) >= 3);