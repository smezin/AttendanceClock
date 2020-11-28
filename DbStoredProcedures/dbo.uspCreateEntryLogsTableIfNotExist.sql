CREATE PROCEDURE [dbo].[uspCreateEntryLogsTableIfNotExist]
	
AS 
IF object_id('EntryLogs', 'U') IS NULL
	BEGIN
		CREATE TABLE [dbo].[EntryLogs]
		(
			[Id]        INT           IDENTITY (1, 1) NOT NULL,
			CONSTRAINT [PK_EntryLogs] PRIMARY KEY CLUSTERED ([Id] ASC),
			[userName]  NVARCHAR (16) NOT NULL,
			[entryTime] DATETIME      NOT NULL,
			[exitTime]  DATETIME      NULL,		
			[loggingSpanSeconds] INT           DEFAULT 0 NOT NULL,
			[LoggingSpanString] NVARCHAR(50) NOT NULL DEFAULT '', 
			CONSTRAINT [FK_Users_userNames] FOREIGN KEY ([userName]) REFERENCES [Users]([userName])
		)
	END
ELSE
	BEGIN
		RETURN 1
	END

RETURN 0