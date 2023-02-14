CREATE Function [dbo].[FDecodificaError] 
(
	@ERROR_NUMBER int, 
	@ERROR_MESSAGE nvarchar(500),
	@ERROR_SEVERITY int,
	@ERROR_STATE int,
	@ERROR_PROCEDURE varchar(200),
	@ERROR_LINE int
	)
RETURNS nvarchar(500)
AS
BEGIN
	RETURN @ERROR_MESSAGE
END