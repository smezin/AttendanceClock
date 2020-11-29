CREATE PROCEDURE [dbo].[uspCreateUsersTableIfNotExist]
	
AS
IF object_id('Users', 'U') IS NULL
	BEGIN
		CREATE TABLE [dbo].[Users]
		(
			[userName] NVARCHAR(16) NOT NULL PRIMARY KEY, 
			[firstName] NVARCHAR(16) NOT NULL, 
			[lastName] NVARCHAR(16) NOT NULL, 
			[hashedPassword] NVARCHAR(255) NOT NULL, 
			[accessLevel] INT  NULL
		)
	END
ELSE
	BEGIN
		RETURN 1
	END

RETURN 0