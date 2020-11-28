CREATE PROCEDURE [dbo].[uspLogTime]
	@userName NVARCHAR(16)
AS
	EXEC uspCreateEntryLogsTableIfNotExist;
	SELECT * FROM EntryLogs
	WHERE userName = @userName 
	AND exitTime IS NULL;

	IF @@ROWCOUNT = 0 
		BEGIN
			INSERT EntryLogs (userName, entryTime)
			VALUES (@userName, CURRENT_TIMESTAMP)
		END
	ELSE
		BEGIN
			DECLARE @duration NVARCHAR(100);
			DECLARE @entryTime DATETIME, @exitTime DATETIME;
			SELECT @exitTime = CAST(CURRENT_TIMESTAMP AS DATETIME);
			SELECT @entryTime = entryTime FROM EntryLogs
			WHERE userName = @userName 
			AND exitTime IS NULL;

			EXEC uspConvertTimeDiffToString @entryTime, @exitTime, @duration OUTPUT;
			UPDATE EntryLogs
			SET exitTime = CURRENT_TIMESTAMP,
				loggingSpanSeconds = DATEDIFF(second, entryTime, CURRENT_TIMESTAMP),
				loggingSpanString = @duration
			WHERE userName = @userName 
			AND exitTime IS NULL;
		END
RETURN