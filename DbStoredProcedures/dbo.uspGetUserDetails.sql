
CREATE PROCEDURE [dbo].[uspGetUserDetails]
	@userName nvarchar(16),
	@userFirstName nvarchar(16) OUTPUT,
	@userLastName nvarchar(16) OUTPUT,
	@userUserName nvarchar(16) OUTPUT,
	@accessLevel INT OUTPUT
AS
BEGIN
	SELECT @userFirstName = firstName, @userLastName = lastName, @userUserName = userName, 
	@accessLevel = accessLevel
	FROM Users
	WHERE userName = @userName
END