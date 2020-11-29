CREATE PROCEDURE [dbo].[uspGetOpenEntry]
	@userName NVARCHAR(16),
	@openEntry DATETIME OUTPUT
AS
	SELECT @openEntry = entryTime FROM EntryLogs
	WHERE userName = @userName
	AND exitTime IS NULL
RETURN 0