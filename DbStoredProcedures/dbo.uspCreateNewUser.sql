CREATE PROCEDURE [dbo].[uspCreateNewUser]
	@userName NVARCHAR(16),
	@firstName NVARCHAR(16),
	@lastName NVARCHAR(16),
	@hashedPassword NVARCHAR(255),
	@accessLevel INT = 0
AS
	EXEC uspCreateUsersTableIfNotExist;
	INSERT INTO Users (userName, firstName, lastName, hashedPassword, accessLevel)
	VALUES (@userName, @firstName, @lastName, @hashedPassword, @accessLevel)
RETURN 0