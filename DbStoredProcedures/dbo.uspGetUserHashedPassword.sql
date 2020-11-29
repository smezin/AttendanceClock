CREATE PROCEDURE [dbo].[uspGetUserHashedPassword]
	@userName nvarchar(16),
	@hashedPassword nvarchar(255) OUTPUT
AS
BEGIN
	SELECT @hashedPassword = hashedPassword
	FROM Users
	WHERE userName = @userName
END