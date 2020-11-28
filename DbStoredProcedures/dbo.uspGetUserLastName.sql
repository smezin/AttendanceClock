CREATE PROCEDURE [dbo].[uspGetUserLastName]
	@userName nvarchar(16),
	@userLastName nvarchar(16) OUTPUT
AS
BEGIN
	SELECT @userLastName = lastName
	FROM Users
	WHERE userName = @userName
END