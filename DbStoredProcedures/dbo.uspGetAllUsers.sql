CREATE PROCEDURE [dbo].[uspGetAllUsers]	
AS
	SELECT userName FROM Users;
RETURN 0