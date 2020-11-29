
--OFFICIAL SOLUTION PROCEDURE PROVIDED BY MICROSOFT
CREATE PROCEDURE [dbo].[uspConvertTimeDiffToString]
	@entryDate DATETIME,
	@exitDate DATETIME,
	@duration NVARCHAR(100) OUTPUT
	AS
		-- DOES NOT ACCOUNT FOR LEAP YEARS
	DECLARE @result VARCHAR(100);
	DECLARE @years INT, @months INT, @days INT,
		@hours INT, @minutes INT, @seconds INT;

	SELECT @years = DATEDIFF(yy, @entryDate, @exitDate)
	IF DATEADD(yy, -@years, @exitDate) < @entryDate 
	SELECT @years = @years-1
	SET @exitDate = DATEADD(yy, -@years, @exitDate)

	SELECT @months = DATEDIFF(mm, @entryDate, @exitDate)
	IF DATEADD(mm, -@months, @exitDate) < @entryDate 
	SELECT @months=@months-1
	SET @exitDate= DATEADD(mm, -@months, @exitDate)

	SELECT @days=DATEDIFF(dd, @entryDate, @exitDate)
	IF DATEADD(dd, -@days, @exitDate) < @entryDate 
	SELECT @days=@days-1
	SET @exitDate= DATEADD(dd, -@days, @exitDate)

	SELECT @hours=DATEDIFF(hh, @entryDate, @exitDate)
	IF DATEADD(hh, -@hours, @exitDate) < @entryDate 
	SELECT @hours=@hours-1
	SET @exitDate= DATEADD(hh, -@hours, @exitDate)

	SELECT @minutes=DATEDIFF(mi, @entryDate, @exitDate)
	IF DATEADD(mi, -@minutes, @exitDate) < @entryDate 
	SELECT @minutes=@minutes-1
	SET @exitDate= DATEADD(mi, -@minutes, @exitDate)

	SELECT @seconds=DATEDIFF(s, @entryDate, @exitDate)
	IF DATEADD(s, -@seconds, @exitDate) < @entryDate 
	SELECT @seconds=@seconds-1
	SET @exitDate= DATEADD(s, -@seconds, @exitDate)


	SELECT @result= ISNULL(CAST(NULLIF(@years,0) AS VARCHAR(10)) + ' years,','')
		 + ISNULL(' ' + CAST(NULLIF(@months,0) AS VARCHAR(10)) + ' months,','')    
		 + ISNULL(' ' + CAST(NULLIF(@days,0) AS VARCHAR(10)) + ' days, and','')
		 + ISNULL(' ' + CAST(NULLIF(@hours,0) AS VARCHAR(10)) + ':h','')
		 + ISNULL(' ' + CAST(@minutes AS VARCHAR(10)) + ':m','')
		 + ISNULL(' ' + CAST(@seconds AS VARCHAR(10)) + ':s','')

	SELECT @duration = @result
RETURN 0